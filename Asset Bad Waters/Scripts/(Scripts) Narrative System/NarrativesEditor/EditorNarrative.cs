using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


#if UNITY_EDITOR
using UnityEditor.SceneManagement;

[CustomEditor(typeof(CinematicController))]
public class EditorNarrative : Editor
{
    CinematicController controller;

    public override void OnInspectorGUI()
    {
        controller = (CinematicController) target;
        GUI.color = Color.red;
        GUILayout.BeginHorizontal();
        GUI.color = Color.white;

        GUILayout.EndHorizontal();

        base.OnInspectorGUI();

        GUI.color = Color.yellow;
        if (GUILayout.Button("[Add Dialogue Assistant]"))
        {
            controller.InstanciateDialogueAssitant<DialogueCineAssistant>();
        }
        GUI.color = Color.white;
        
        //if (controller.missionAnimations.Count > 0)
        //{
        //    foreach (CinematicAssistant assi in controller.missionAnimations)
        //    {
        //        EditorGUILayout.BeginHorizontal();

        //        if (controller.missionAnimations.IndexOf(assi) == controller.misionIndex+1)
        //        {
        //            GUI.color = Color.green;
        //            if (GUILayout.Button("i",GUILayout.Width(15)))
        //            {
        //               controller.SetIndexMission(assi);
        //            }
        //        }
        //        else
        //        {
        //            GUI.color = Color.white;
        //            if (GUILayout.Button("", GUILayout.Width(15)))
        //            {
        //                controller.SetIndexMission(assi);
        //            }
        //        }


        //        //GUI.color = (controller.IDLastButtonAssistants == assi.GetInstanceID()) ? Color.cyan : Color.white;
                
        //        if (GUILayout.Button((assi !=null)?assi.gameObject.name:"null"))
        //        {
        //            controller.IDLastButtonAssistants = assi.GetInstanceID();
        //            Selection.activeObject = assi;
        //        }

        //        GUI.color = Color.red;
        //        if (GUILayout.Button("-",GUILayout.Width(30)))
        //        {
        //            //assi.SelfDestroy();
        //        }
        //        GUI.color = Color.white;

        //        if (GUILayout.Button("<", GUILayout.Width(30)))
        //        {
        //            Organizer<CinematicAssistant>.MoveIndexOfAList(assi,controller.missionAnimations,true);
        //        }

        //        if (GUILayout.Button(">", GUILayout.Width(30)))
        //        {
        //            Organizer<CinematicAssistant>.MoveIndexOfAList(assi, controller.missionAnimations, false);
        //        }

        //        EditorGUILayout.EndHorizontal();
        //    }

        //    base.OnInspectorGUI();
        //}

        if (GUI.changed)
        {
            EditorUtility.SetDirty(controller);
            EditorSceneManager.MarkSceneDirty(controller.gameObject.scene);
        }
    }

    private void CollapseDialogueSettings()
    {
        //controller.positionInChar1 = EditorGUILayout.Vector3Field("Pos Char1 In",controller.positionInChar1);

        SerializedProperty dialogue;
        dialogue = serializedObject.FindProperty("dialogue");
        EditorGUILayout.PropertyField(dialogue, new GUIContent("Dialogue"));

        serializedObject.ApplyModifiedProperties();
    }

}
#endif
