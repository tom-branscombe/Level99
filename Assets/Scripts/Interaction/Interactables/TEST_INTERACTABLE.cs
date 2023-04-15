using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_INTERACTABLE : Interactable
{


    public override void OnInteract()
    {
        //Test interactables.
        Debug.Log("on interaction test, name = " + gameObject.name);
    }
}
