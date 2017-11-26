using System.Collections;
using System.Collections.Generic;
using Assets.Script;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpawnPoint))]
[CanEditMultipleObjects]
public class SpawnPointTools : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.Update();
        if (GUILayout.Button("Spawn"))
        {
            SpawnPoint spawnPoint = serializedObject.targetObject as SpawnPoint;
            if (spawnPoint != null)
                spawnPoint.PerformSpawn();
        }
        serializedObject.ApplyModifiedProperties();
    }
}