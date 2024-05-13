using System.Collections;
using System.Collections.Generic;
using DINO.TopDown2D.BSG;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CurrencyManager))]
public class CurrencyManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        CurrencyManager currencyManager = (CurrencyManager) target;
        base.OnInspectorGUI();
        if (GUILayout.Button("Add Currency"))
        {
            currencyManager.AddCurrency(100);
        }
        if (GUILayout.Button("Remove Currency"))
        {
            currencyManager.SpendCurrency(20);
        }
    }
}
