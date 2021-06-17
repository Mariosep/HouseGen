using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Wall))]
public class WallEditor : Editor
{
    private SerializedProperty wallPiecePrefabProp;
    private SerializedProperty wallSizeProp;
    private SerializedProperty wallPieceListProp;

    private Wall wall;

    private void OnEnable()
    {
        wall = target as Wall;
        
        // Setup Serialized properties
        wallPiecePrefabProp = serializedObject.FindProperty("wallPiecePrefab");
        wallSizeProp = serializedObject.FindProperty("wallSize");
        wallPieceListProp = serializedObject.FindProperty("wallPieceList");
    }

    public override void OnInspectorGUI()
    {
        // Update the serializedProperty - always do this in the beginning of OnInspectorGUI.
        serializedObject.Update ();

        EditorGUILayout.PropertyField(wallPiecePrefabProp);
        EditorGUILayout.IntSlider(wallSizeProp, 0, 10);
        //EditorGUILayout.PropertyField(wallPieceListProp);
        
        if (GUILayout.Button("Add to left"))
            wall.AddWallPiece();
        
        if (GUILayout.Button("Add to right"))
            wall.RemoveWallPiece();
        
        /*// Show the custom GUI controls.
        EditorGUILayout.IntSlider (damageProp, 0, 100, new GUIContent ("Damage"));

        // Only show the damage progress bar if all the objects have the same damage value:
        if (!damageProp.hasMultipleDifferentValues)
            ProgressBar (damageProp.intValue / 100.0f, "Damage");

        EditorGUILayout.IntSlider (armorProp, 0, 100, new GUIContent ("Armor"));

        // Only show the armor progress bar if all the objects have the same armor value:
        if (!armorProp.hasMultipleDifferentValues)
            ProgressBar (armorProp.intValue / 100.0f, "Armor");*/

        //EditorGUILayout.PropertyField (gunProp, new GUIContent ("Gun Object"));

        // Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.
        serializedObject.ApplyModifiedProperties ();
    }
}
