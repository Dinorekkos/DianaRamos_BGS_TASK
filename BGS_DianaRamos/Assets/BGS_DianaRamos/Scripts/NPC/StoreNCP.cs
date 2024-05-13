using System;
using System.Collections;
using System.Collections.Generic;
using Dino.TopDown2D;
using DINO.Utility;
using UnityEngine;

public class StoreNCP : InteractionObject
{
    [SerializeField] private string _storeName = "clothe.store";
    protected override void Interact()
    {        
        if(InteractionsManager.Instance.CurrentInteractionObject != this) return;
        base.Interact();
        Debug.Log("Interacting with Store".SetColor("#89FF89"));
        
        MenuManager.Intance.OpenWindow(MenuManager.Intance.GetWindow(_storeName));
    }
  
    
    
    
    
  
}
