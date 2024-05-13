using System;
using System.Collections;
using System.Collections.Generic;
using DINO.TopDown2D.BSG;
using UnityEngine;

public class InteractionsManager : MonoBehaviour
{
    public static InteractionsManager _instance;
    public static InteractionsManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<InteractionsManager>();
            }

            return _instance;
        }
    }

    public InteractionObject CurrentInteractionObject
    {
        get
        {
            return _currentInteractionObject;
        }
        set
        {
            _currentInteractionObject = value;
            // Debug.Log("Current Interaction Object: " + _currentInteractionObject.name);
        }
        
    }
    
    private InteractionObject _currentInteractionObject;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
