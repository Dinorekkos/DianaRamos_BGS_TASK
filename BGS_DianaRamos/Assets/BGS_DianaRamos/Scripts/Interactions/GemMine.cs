using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemMine : InteractionObject
{
    protected override void Interact()
    {
        if(InteractionsManager.Instance.CurrentInteractionObject != this) return;
        base.Interact();
        
        Debug.Log("Interacting with Gem Mine");
    }

}
