/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(Quest))]

public class QuestEditor : Editor
{

    Quest quest;
    ReorderableList objectiveList;

    private void OnEnable()
    {
        quest = (Quest)target;
        if (quest.objective == null)
        {
            quest.objective = new List<Objective>();
        }
        objectiveList = new ReorderableList(serializedObject, serializedObject.FindProperty("objective"), true, true, true, true);

        objectiveList.onAddCallback = OnAddCallBack;
        objectiveList.onRemoveCallback = OnRemoveCallBack;
        objectiveList.drawElementCallback = DrawElement;
        objectiveList.onReorderCallback = (list) =>
        {
            quest.transform.DetachChildren();
            for (int i = 0; i < quest.objective.Count; i++)
            {
                quest.objective[i].transform.parent = quest.transform;
            }
        };
    }

    void OnAddCallBack(ReorderableList list)
    {
        var obj = new GameObject("Objective_" + quest.objective.Count).AddComponent<Objective>();
        obj.quest = quest;
        quest.objective.Add(obj);
        obj.transform.parent = quest.transform;
        Undo.RegisterFullObjectHierarchyUndo(quest, "Added an Objective");
    }
    void DrawElement(Rect rect, int index, bool isActive, bool isFocused)
    {
        var element = objectiveList.serializedProperty.GetArrayElementAtIndex(index);
        EditorGUI.PropertyField(
            new Rect(rect.x, rect.y + 2, rect.width, rect.height), element);
    }

    void OnRemoveCallBack(ReorderableList list)
    {
        var index = list.index;
        GameObject.DestroyImmediate(quest.objective[index].gameObject);
        quest.objective.RemoveAt(index);
    }
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        DeleteMissingObjects();

        objectiveList.DoLayoutList();
        if (EditorApplication.isPlaying)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("currentObjective"));
            GUI.enabled = true;
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Previous"))
            {
                quest.Previous();
            }
            if (GUILayout.Button("Next"))
            {
                quest.Next();
            }
            GUILayout.EndHorizontal();


        }

       
    }


    void DeleteMissingObjects()
    {
        for (int i = quest.objective.Count - 1; i >= 0; i--)
        {
            if (quest.objective[i] == null)
            {
                quest.objective.RemoveAt(i);
            }
        }
    }

}
*/