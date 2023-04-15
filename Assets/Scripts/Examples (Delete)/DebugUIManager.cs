using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class DebugUIManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] TMPro.TextMeshProUGUI _textTooltip;
    [SerializeField] InteractableEventChannelSO _interactEvent;


    Canvas _canvas;

    private void Awake()
    {
        _canvas= GetComponent<Canvas>();

    }


    private void OnEnable()
    {
        _interactEvent.OnEventRaised += OnInteractEvent;
    }

    private void OnDisable()
    {
        _interactEvent.OnEventRaised -= OnInteractEvent;
    }

    private void OnInteractEvent(Interactable interact)
    {
        if (interact == null)
        {
            //Remove current tooltip.
            _textTooltip.text = "";
            _textTooltip.enabled = false;
            return;
        }

        _textTooltip.text = interact.Tooltip;
        _textTooltip.enabled = true;
        _textTooltip.transform.position = Camera.main.WorldToScreenPoint(interact.transform.position);
    }




}
