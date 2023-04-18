using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInteractable : Interactable
{

    [SerializeField] Canvas _bookCanvas;


    public override string Tooltip => "Book";

    private bool isOpen = false;

    public override void OnInteract()
    {
        _bookCanvas.gameObject.SetActive(!isOpen);
        isOpen = !isOpen;

        //Freeze/Unfreeze player.
        //Player.freeze(isOpen)

    }
}
