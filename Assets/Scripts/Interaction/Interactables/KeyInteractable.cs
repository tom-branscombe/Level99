using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteractable : Interactable
{
    public override string Tooltip => "Key";

    public override void OnInteract()
    {



        //Add the key to the players inventory.


        //Maybe add some text animation to show the player that they gained the key.


        //Disable interactable object.
        Destroy(this.gameObject);
    }
}
