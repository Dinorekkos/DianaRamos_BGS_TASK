using System;
using System.Collections;
using System.Collections.Generic;
using DINO.Utility;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    #region Singleton
    
    private static MenuManager _instance;

    public static MenuManager Intance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MenuManager>();
                if (_instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "MenuManager";
                    _instance = go.AddComponent<MenuManager>();
                }
            }

            return _instance;
        }
    }
    #endregion
    [SerializeField] List<MenuWindow> _menuWindows = new List<MenuWindow>();

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        Initialize();
    
    }

    private void Initialize()
    {
        
    }

    public void OpenWindow(MenuWindow window)
    {
        window.ShowWindow();
    }
    
    
    public MenuWindow GetWindow(string windowName)
    {
        return _menuWindows.Find(x => x.WindowName == windowName);
    }
    
}
