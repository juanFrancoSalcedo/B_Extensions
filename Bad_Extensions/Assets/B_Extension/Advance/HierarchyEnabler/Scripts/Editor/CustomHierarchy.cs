using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;

namespace B_Extensions.HierarchyStates
{
    [InitializeOnLoad]
    class CustomHierarchy
    {
        static readonly Dictionary<int, StateSetter> s_StateMap = new Dictionary<int, StateSetter>();
        static readonly Dictionary<int, ColorHierarchySetter> s_ColorMap = new Dictionary<int, ColorHierarchySetter>();
#if !UNITY_6000_6_OR_NEWER
        static int s_Tick;
#endif

        static CustomHierarchy()
        {
#if UNITY_6000_6_OR_NEWER
            EditorApplication.hierarchyWindowItemByEntityIdOnGUI += HierarchyItemByEntityIdCB;
#else
            EditorApplication.hierarchyWindowItemOnGUI += HierarchyItemCB;
            EditorApplication.hierarchyChanged += RebuildMaps;
            EditorApplication.update += PollRebuildMaps;
            RebuildMaps();
#endif
        }

#if UNITY_6000_6_OR_NEWER
        static void HierarchyItemByEntityIdCB(EntityId entityId, Rect selectionRect)
        {
            GameObject obj = EditorUtility.EntityIdToObject(entityId) as GameObject;
            if (obj == null) return;

            DrawHierarchyColor(selectionRect, obj.GetComponent<ColorHierarchySetter>());
            DrawStateToggle(selectionRect, obj.GetComponent<StateSetter>(), obj);
        }
#else
        static void PollRebuildMaps()
        {
            if (++s_Tick < 60) return;
            s_Tick = 0;
            RebuildMaps();
        }

        static void RebuildMaps()
        {
            s_StateMap.Clear();
            s_ColorMap.Clear();

            StateSetter[] states = Resources.FindObjectsOfTypeAll<StateSetter>();
            foreach (var s in states)
            {
                if (s != null && s.gameObject.scene.IsValid())
                    s_StateMap[s.gameObject.GetInstanceID()] = s;
            }

            ColorHierarchySetter[] colors = Resources.FindObjectsOfTypeAll<ColorHierarchySetter>();
            foreach (var c in colors)
            {
                if (c != null && c.gameObject.scene.IsValid())
                    s_ColorMap[c.gameObject.GetInstanceID()] = c;
            }
        }

        static void HierarchyItemCB(int instanceID, Rect selectionRect)
        {
            if (s_ColorMap.TryGetValue(instanceID, out ColorHierarchySetter colorItem))
                DrawHierarchyColor(selectionRect, colorItem);

            if (s_StateMap.TryGetValue(instanceID, out StateSetter stateItem))
                DrawStateToggle(selectionRect, stateItem, stateItem.gameObject);
        }
#endif

        public static void SearchEnablers()
        {
            var stateSetters = Resources.FindObjectsOfTypeAll<StateSetter>();
            foreach (var item in stateSetters)
            {
                if (!item.gameObject.scene.IsValid()) continue;

                item.EnableOnHierarchy();
                EditorUtility.SetDirty(item);
                EditorSceneManager.MarkSceneDirty(item.gameObject.scene);
            }
        }

        private static void DrawHierarchyColor(Rect selectionRect, ColorHierarchySetter colorItem)
        {
            if (colorItem == null) return;

            Rect toDrawOne = selectionRect;
            Rect toDrawFill = selectionRect;
            Rect toDrawThree = selectionRect;

            toDrawOne.height = toDrawThree.height = 1;
            toDrawFill.height = 8;
            toDrawFill.x += 50;

            toDrawFill.y += 4;
            toDrawThree.y += 16;

            var colorFull = colorItem.colorInHierarchy;
            colorFull.a = 0.08f;

            EditorGUI.DrawRect(toDrawOne, colorItem.colorInHierarchy);
            EditorGUI.DrawRect(toDrawFill, colorFull);
            EditorGUI.DrawRect(toDrawThree, colorItem.colorInHierarchy);
        }

        private static void DrawStateToggle(Rect selectionRect, StateSetter stateItem, GameObject gameObject)
        {
            if (stateItem == null) return;

            Rect buttonRect = new Rect(selectionRect);
            buttonRect.height = 16;
            buttonRect.x = selectionRect.xMax - 20;
            buttonRect.width = 20;

            if (GUI.Button(buttonRect, stateItem.stateEnable ? "O" : ""))
            {
                Undo.RecordObject(stateItem, "Toggle State");
                stateItem.stateEnable = !stateItem.stateEnable;
                stateItem.EnableOnHierarchy();
                EditorUtility.SetDirty(stateItem);
                EditorSceneManager.MarkSceneDirty(gameObject.scene);
            }
        }
    }
}
