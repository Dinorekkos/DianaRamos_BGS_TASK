using System;
using System.Collections;
using System.Collections.Generic;
using DINO.TopDown2D.BSG;
using DINO.Utility;
using UnityEngine;

public class StoreNCP : InteractionObject
{
    [SerializeField] private string _storeName = "clothe.store";
    protected override void Interact()
    {        
        if(InteractionsManager.Instance.CurrentInteractionObject != this) return;
        base.Interact();
        
        MenuManager.Intance.OpenWindow(MenuManager.Intance.GetWindow(_storeName));
        
        PlayerMovement.Instance.EnableMovement(false);
        Vector2 directionDown = new Vector2(0, -1);
        PlayerMovement.Instance.SetAnimToFixedDirection(directionDown);
    }
  
    
    
    
    
  
}
