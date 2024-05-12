using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemMine : InteractionObject
{
    protected override void Interact()
    {
        base.Interact();
        Debug.Log("Interacting with Gem Mine");
    }

}
