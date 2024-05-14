using System.Collections;
using System.Collections.Generic;
using DINO.TopDown2D.BSG;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CharacterPartSelector))]
public class CharacterSelectorEditor : Editor
{
    private CharacterPartSelector _characterPartSelector;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        _characterPartSelector = (CharacterPartSelector) target;
        GUILayout.Space(10);

        
        if (GUILayout.Button("Select New Body Part"))
        {
            _characterPartSelector.ChangeBodyPart(_characterPartSelector._testBodyPart, 0);
        }
        
        
    }
}
