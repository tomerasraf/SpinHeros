using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WorldData))]
public class ResetLevelData : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        WorldData _worldData = (WorldData)target;

        if (GUILayout.Button("Reset Level Data", GUILayout.Height(40))) {

            _worldData.ResetWorldData();
        }
    }
}
