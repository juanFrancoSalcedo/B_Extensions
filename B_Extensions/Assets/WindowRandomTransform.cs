using UnityEditor;
using UnityEngine;
public class WindowRandomTransform : EditorWindow
{
    [MenuItem("B_extensions/3D extensions/Randomize Scale Rotation")]
    public static void ShowWindow()
    {

        GetWindow<WindowRandomTransform>("Custom Window");
    }

    private void OnGUI()
    {
        
        if (GUILayout.Button("Random Scale"))
        {
            GameObject[] seleccionados = Selection.gameObjects;
            foreach (var item in seleccionados)
            {
                item.transform.localScale = Vector3.one * Random.Range(1f,2f); 
            }

        }

        if (GUILayout.Button("Random Rotation"))
        {
            GameObject[] seleccionados = Selection.gameObjects;


            foreach (GameObject go in seleccionados)
            {

                float randomY = Random.Range(0f, 360f);


                go.transform.localRotation = Quaternion.Euler(0, randomY, 0);

            }
        }
    }
}
