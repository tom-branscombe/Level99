using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.UI.Image;


/// <summary>
/// Handle player interactions. Put on a gameObject inside of the player.
/// </summary>
public class PlayerInteraction : MonoBehaviour
{
    
    private List<Interactable> interactablesInRange;

    [Header("Input Reader")]
    [SerializeField] InputReaderSO _inputReader = default;

    [Header("Interaction Settings")]
    //Radius changed on startup.
    [SerializeField] float radius;
    [SerializeField] LayerMask interactionMask;

    Interactable currentClosestInteractable;

    private void OnDrawGizmos()
    {
        //Draw debug sphere
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.forward, radius);
        Handles.color = Color.white;
    }

    private void OnEnable()
    {
        //Register to interact control press
        _inputReader.interactionEvent += OnInteract;  
    }
    private void OnDisable()
    {
        //Unsubscrive on disable.
        _inputReader.interactionEvent -= OnInteract;
    }
    private void FixedUpdate()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius, interactionMask);


        var newClosest = getClosestInteractable(hitColliders);
        if (newClosest == null)
        {
            //Send null string event, removing the tooltip.
            OnNewInteractable(null);
            currentClosestInteractable = null;
            return;
        }
        if (newClosest == currentClosestInteractable) return;

        //Invoke new closest event to UI
        OnNewInteractable(newClosest);

        currentClosestInteractable = newClosest;

        
    }




    Interactable getClosestInteractable(Collider2D[] colliders)
    {

        if (colliders.Length == 0) return null;
        if (colliders.Length == 1) return getInteractable(colliders[0]);

        Collider2D closest = colliders[0];
        float distance = Vector2.Distance(closest.gameObject.transform.position, transform.position);

        foreach (Collider2D obj in colliders)
        {
            float objDistance = Vector2.Distance(obj.gameObject.transform.position, transform.position);
            if (objDistance < distance)
            {
                closest = obj;
                distance = objDistance;
            }
        }
        return getInteractable(closest);
    }


    Interactable getInteractable(Collider2D collider)
    {
        if(collider.TryGetComponent<Interactable>(out var interactable))
        {
            return interactable;
        }
        Debug.LogError("Error, No interactable script inside object with interactable layer. objectname = " + collider.name);
        return null;
    }


    private void OnInteract()
    {
        if (currentClosestInteractable == null) return;
        currentClosestInteractable.OnInteract();
    }

    private void OnNewInteractable(Interactable interact)
    {
        string printString = interact ? interact.name : "null";
        Debug.Log(printString);

    }


}
