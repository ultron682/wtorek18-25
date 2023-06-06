using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelGenerator))]
public class EditorButton : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        DrawDefaultInspector();
        LevelGenerator generator = (LevelGenerator)target;

        if( GUILayout.Button("Generate map"))
        {
            generator.GenerateLabirynth();
        }
    }
}
