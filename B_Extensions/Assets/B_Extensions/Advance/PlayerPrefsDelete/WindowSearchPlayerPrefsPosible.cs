using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



<<<<<<<< HEAD:B_Extensions/Assets/B_Extension/Advance/PlayerPrefsDelete/WindowSearchPlayerPrefsPosible.cs
namespace B_Extensions
========
namespace B_extensions
>>>>>>>> 9c4bc29519a438132e66a381b77b02e5aa7eca6e:B_Extensions/Assets/B_Extensions/Advance/PlayerPrefsDelete/WindowSearchPlayerPrefsPosible.cs
{
#if UNITY_EDITOR

    public class WindowSearchPlayerPrefsPosible : EditorWindow
    {
<<<<<<<< HEAD:B_Extensions/Assets/B_Extension/Advance/PlayerPrefsDelete/WindowSearchPlayerPrefsPosible.cs
        [MenuItem("B_Extensions/PlayerPrefs Elimination")]
========
        [MenuItem("B_extensions/PlayerPrefs Elimination")]
>>>>>>>> 9c4bc29519a438132e66a381b77b02e5aa7eca6e:B_Extensions/Assets/B_Extensions/Advance/PlayerPrefsDelete/WindowSearchPlayerPrefsPosible.cs
        public static void ShowWindow()
        {
            //PlayerPrefs.SetString(KeyStorage.PlayersTest, "Hola Mundo");
            SearchPlayerPrefs();
            EditorWindow window = GetWindow(typeof(WindowSearchPlayerPrefsPosible));
            window.Show();
        }

        static List<string> bufferSearch = new List<string>();
        private void OnGUI()
        {

            if (GUILayout.Button("Delete All"))
            {
                PlayerPrefs.DeleteAll();
                SearchPlayerPrefs();
            }
            if (!ExistsSearch)
            {
                GUIStyle textStyle = EditorStyles.label;
                textStyle.wordWrap = true;
                Vector2 p = new Vector2(0, 30f);
                Vector2 s = new Vector2(position.width, 200f);
                var textRect = new Rect(p, s);
                string text = "Se busca dependiendo de los Player Prefs guardados como llaves en la clase \"KeyStorage\"";
                EditorGUI.LabelField(textRect, text, textStyle);
                return;
            }

            try
            {
                foreach (var item in bufferSearch)
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.Label(item);
                    if (GUILayout.Button("Delete"))
                    {
                        PlayerPrefs.DeleteKey(item);
                        SearchPlayerPrefs();
                    }

                    if (GUILayout.Button("Show"))
                    {
                        Debug.Log("Float:"+PlayerPrefs.GetFloat(item));
                        Debug.Log("Int:" + PlayerPrefs.GetInt(item));
                        Debug.Log("String:" + PlayerPrefs.GetString(item));

                    }
                    GUILayout.EndHorizontal();
                }
            }
            catch (System.Exception) { }

            this.Repaint();
        }

        public static void SearchPlayerPrefs()
        {
            bufferSearch.Clear();
            foreach (var item in typeof(KeyStorage).GetFields())
            {
                var valueItem = item.GetValue(item).ToString();
                if (PlayerPrefs.HasKey(valueItem))
                    bufferSearch.Add(valueItem);
            }
        }
        private static bool ExistsSearch => bufferSearch.Count > 0;
    }
#endif
}
