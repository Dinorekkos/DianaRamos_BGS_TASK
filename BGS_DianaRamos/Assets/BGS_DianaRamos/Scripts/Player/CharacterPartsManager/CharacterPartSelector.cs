using System;
using System.Collections;
using System.Collections.Generic;
using DINO.Utility;
using UnityEngine;

public class CharacterPartSelector : MonoBehaviour
{
    #region Singleton
    private static CharacterPartSelector _instance;
    public static CharacterPartSelector Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CharacterPartSelector>();
                if (_instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "CharacterPartSelector";
                    _instance = go.AddComponent<CharacterPartSelector>();
                }
            }

            return _instance;
        }
    }
    #endregion
    
    #region Serialized Fields
    [SerializeField] private CharacterBodyData _characterBodyData;
    [SerializeField] private BodyPartSelection[] bodyPartSelections;
    #endregion

    #region Public variables
    public string _testBodyPart; 
    public int _testCharacterPartData;
    public Action OnBodyPartUpdate;
    #endregion
    

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
        for (int i = 0; i < bodyPartSelections.Length; i++)
        {
            GetCurrentBodyParts(i);
        }
    }
    
    public void ChangeBodyPart(string bodyPartName, int newCharacterPartDataIndex)
    {
        // Buscar el índice de la parte del cuerpo que coincide con bodyPartName
        int bodyPartIndex = Array.FindIndex(bodyPartSelections, bp => bp.bodyPartName == bodyPartName);

        // Validar si el índice es válido
        if (bodyPartIndex == -1)
        {
            Debug.Log($"No se encontró la parte del cuerpo: {bodyPartName}");
            return;
        }

        // Cambiar el CharacterPartData de la parte del cuerpo al índice proporcionado
        bodyPartSelections[bodyPartIndex].bodyPartCurrentIndex = newCharacterPartDataIndex;

        // Actualizar la parte del cuerpo en el CharacterPartsManager
        UpdateCurrentPart(bodyPartIndex);
    }
    
    
    private bool ValidateIndexValue(int partIndex)
    {
        if (partIndex > bodyPartSelections.Length || partIndex < 0)
        {
            Debug.Log("Index value does not match any body parts!");
            return false;
        }
        else
        {
            return true;
        }
    }
    
    private void GetCurrentBodyParts(int partIndex)
    {
        BodyPartSelection currentBodyPartSelection = bodyPartSelections[partIndex];
        BodyPart currentBodyPart = _characterBodyData.characterBodyParts[partIndex];
        int currentBodyPartAnimationID = currentBodyPart.CharacterPartData.BodyPartAnimationID;
        currentBodyPartSelection.bodyPartCurrentIndex = currentBodyPartAnimationID;
        
        Debug.Log("Current Body Part: ".SetColor("") + currentBodyPartSelection.bodyPartName + " : " + currentBodyPartAnimationID);
        
    }
    
    private void UpdateCurrentPart(int partIndex)
    {
        BodyPartSelection currentSelection = bodyPartSelections[partIndex];
        int currentIndex = currentSelection.bodyPartCurrentIndex;
        CharacterPartData currentPartData = currentSelection.CharacterPartOptions[currentIndex];
        _characterBodyData.characterBodyParts[partIndex].CharacterPartData = currentPartData;
        
        OnBodyPartUpdate?.Invoke();
        Debug.Log("Updated Body Part: ".SetColor("") + currentSelection.bodyPartName + " : " + currentIndex);
        
    }

    
    
}

[Serializable]
public class BodyPartSelection
{
    public string bodyPartName;
    public CharacterPartData[] CharacterPartOptions;
    [HideInInspector] public int bodyPartCurrentIndex;
}