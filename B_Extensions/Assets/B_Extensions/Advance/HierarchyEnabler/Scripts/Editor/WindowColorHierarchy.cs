using UnityEditor;
using UnityEngine;

namespace B_extensions.HierarchyStates
{
    public class WindowColorHierarchy : EditorWindow
    {
#if UNITY_EDITOR
        [MenuItem("GameObject/Change Color Hierarchy", false, 12)]
        public static void ShowWindow()
        {
            GetWindow<WindowColorHierarchy>("HierarchyEditor");
        }

        [MenuItem("GameObject/State/Add %e", false, 11)]
        public static void AddState()
        {

            foreach (var item in Selection.gameObjects)
            {
                if (!item.GetComponent<ColorHierarchySetter>())
                {
                    item.AddComponent(typeof(StateSetter));
                }
            }
        }

        private Color bufferColor = new Color(0.6f, 0.4f, 0.6f, 0.7f);
        private void OnGUI()
        {
            bufferColor = EditorGUILayout.ColorField("Color to " + Selection.activeGameObject.name, bufferColor);

            if (GUILayout.Button("Apply Color"))
            {
                foreach (var item in Selection.gameObjects)
                {
                    if (!item.GetComponent<ColorHierarchySetter>())
                    {
                        item.AddComponent(typeof(ColorHierarchySetter));
                        item.GetComponent<ColorHierarchySetter>().colorInHierarchy = bufferColor;
                    }

                }
                this.Close();
            }

            if (GUILayout.Button("Remove Color"))
            {

                foreach (var item in Selection.gameObjects)
                {
                    if (item.GetComponent<ColorHierarchySetter>())
                    {
                        DestroyImmediate(item.GetComponent<ColorHierarchySetter>());
                        this.Close();
                    }
                }
            }
        }
#endif
    }
}