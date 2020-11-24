using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class NewSpawner : EditorWindow
{
    public int CriatingObjectsCounter;
    public bool IsAdditionalFeaturesActive;

    private void OnGUI()
    {
        GUILayout.Label("Настройки", EditorStyles.label);
        IsAdditionalFeaturesActive = EditorGUILayout.BeginToggleGroup("Включить", IsAdditionalFeaturesActive);
        CriatingObjectsCounter = EditorGUILayout.IntSlider("Количество обьектов", CriatingObjectsCounter, 1, 10);

        EditorGUILayout.EndToggleGroup();
    }
}
