/////////////////////////////////////////////
//// Codewart Game Assets 2021
//// CustomButton.cs
//// Description: UI buttons in inspector
//// License: Use or modify as you need
//// Contact: support@codewart.com
//// Unity Asset Store: https://assetstore.unity.com/publishers/49258
/////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ModulesShaker))]
public class customButton : Editor
{
    public override void OnInspectorGUI()
    {
        
        ModulesShaker myScript = (ModulesShaker)target;

        GUILayout.Label("Choose gender:");

        myScript.gender_idx = EditorGUILayout.Popup(myScript.gender_idx, myScript.Gender);       

        if (GUILayout.Button("Set all elements by numeration"))
        {
            myScript.SetAll(myScript.set_numeration);
        }

        if (GUILayout.Button("Randomize All (one package)"))
        {
            myScript.RandomizeAll();
        }

        if (GUILayout.Button("Randomize All (including other packages)"))
        {
            myScript.RandomizeAllOther();
        }

        DrawDefaultInspector();

    }

}