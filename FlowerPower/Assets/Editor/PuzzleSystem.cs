using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal; //No documentation

/*
[CustomEditor(typeof(Levels))]

public class PuzzleSystem : Editor
{
    ReorderableList puzzleList;
    Levels levels;

    private void OnEnable()
    {
        levels = (Levels)target;

        if (null == levels.objectives)
        {
            levels.objectives = new List<Objective>();
        }

        puzzleList = new ReorderableList(serializedObject, serializedObject.FindProperty("objectives"), true, true, true, true);

        puzzleList.onAddCallback = OnAddCallbackFunction;
        puzzleList.onRemoveCallback = OnRemoveCallbackFunction;
        puzzleList.drawElementCallback = DrawElement;
        puzzleList.onReorderCallback = OnReorderCallBackFunction;
    }

    void OnReorderCallBackFunction(ReorderableList list)
    {
        levels.transform.DetachChildren();
        for (int i = 0; i < levels.objectives.Count; i++)
        {
            levels.objectives[i].transform.parent = levels.transform;
        }
    }

    void OnAddCallbackFunction(ReorderableList list)
    {
        DeleteMissingObject();
        var obj = new GameObject("Objective No:" + levels.objectives.Count).AddComponent<Objective>();
        obj.quest = levels;
        levels.objectives.Add(obj);
        obj.transform.parent = levels.transform;
        Undo.RegisterFullObjectHierarchyUndo(levels, "Added an Level");
    }

    void OnRemoveCallbackFunction(ReorderableList list)
    {
        var index = list.index;
        GameObject.DestroyImmediate(quest.objectives[index].gameObject);//"Destroy" Waits until the end of the frame then destroys. 
        quest.objectives.RemoveAt(index);
    }

    void DrawElement(Rect rect, int index, bool isActive, bool isFocused)
    {
        var element = objectivesList.serializedProperty.GetArrayElementAtIndex(index);
        EditorGUI.PropertyField(new Rect(rect.x, rect.y + 2, rect.width, EditorGUIUtility.singleLineHeight), element, GUIContent.none);
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        DeleteMissingObject();
        objectivesList.DoLayoutList();

        GUI.enabled = false;
        EditorGUILayout.PropertyField(serializedObject.FindProperty("currentObjective"));
        GUI.enabled = true;

        if (EditorApplication.isPlaying)
        {
            GUILayout.BeginHorizontal();
            if (quest.current == 0)
            {
                GUI.enabled = false;
            }

            if (GUILayout.Button("Previous"))
            {
                quest.Previous();
            }

            GUI.enabled = true;

            if (quest.current >= objectivesList.count - 1)
            {
                GUI.enabled = false;
            }

            if (GUILayout.Button("Next"))
            {
                quest.Next();
            }
            GUILayout.EndHorizontal();
        }
    }

    void DeleteMissingObject()
    {
        for (int i = quest.objectives.Count - 1; i >= 0; i--)
        {
            if (quest.objectives[i] == null)
            {
                quest.objectives.RemoveAt(i);
            }
        }
    }*/