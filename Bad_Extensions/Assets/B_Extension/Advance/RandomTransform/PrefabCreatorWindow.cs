using UnityEngine;
using UnityEditor;

public class PrefabCreatorWindow : EditorWindow
{
    private GameObject selectedObject;
    private string prefabName = "";

    // Rutas predefinidas
    private const string PREFABS_PATH = "Assets/Level/Prefabs/";
    private const string UI_PREFABS_PATH = "Assets/Level/Prefabs/UI/";

    [MenuItem("B_Extensions/Hierarchy Extension/Create Prefab Windows")]
    public static void ShowWindow()
    {
        GetWindow<PrefabCreatorWindow>("Crear Prefab");
    }

    private void OnEnable()
    {
        selectedObject = Selection.activeGameObject;
        if (selectedObject != null)
        {
            prefabName = selectedObject.name;
        }
    }

    private void OnGUI()
    {
        // Título
        EditorGUILayout.LabelField("Crear Prefab desde Selección", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        // Mostrar objeto seleccionado
        EditorGUILayout.BeginVertical("box");
        EditorGUILayout.LabelField("Objeto Seleccionado:");
        selectedObject = (GameObject)EditorGUILayout.ObjectField(
            selectedObject,
            typeof(GameObject),
            true
        );

        // Mostrar tipo de destino detectado
        if (selectedObject != null)
        {
            bool isUI = HasRectTransform(selectedObject);
            string typeLabel = isUI ? "📱 UI (RectTransform)" : "🎮 GameObject (Transform)";
            Color originalColor = GUI.contentColor;
            GUI.contentColor = isUI ? new Color(0.4f, 0.8f, 1f) : new Color(0.4f, 1f, 0.6f);
            EditorGUILayout.LabelField("Tipo detectado: " + typeLabel);
            GUI.contentColor = originalColor;
        }
        EditorGUILayout.EndVertical();

        EditorGUILayout.Space();

        // Nombre del prefab
        EditorGUILayout.BeginVertical("box");
        prefabName = EditorGUILayout.TextField("Nombre del Prefab:", prefabName);
        EditorGUILayout.EndVertical();

        EditorGUILayout.Space();

        // Mostrar ruta de guardado
        EditorGUILayout.BeginVertical("box");
        string savePath = GetSavePath(selectedObject);
        EditorGUILayout.LabelField("Ruta de Guardado:");
        Color originalColor2 = GUI.contentColor;
        GUI.contentColor = Color.yellow;
        EditorGUILayout.LabelField(savePath);
        GUI.contentColor = originalColor2;
        EditorGUILayout.EndVertical();

        EditorGUILayout.Space();

        // Botón crear
        GUI.backgroundColor = Color.green;
        if (GUILayout.Button("Crear Prefab", GUILayout.Height(40)))
        {
            CreatePrefab();
        }
        GUI.backgroundColor = Color.white;

        EditorGUILayout.Space();

        // Información del atajo rápido
        EditorGUILayout.BeginVertical("box");
        EditorGUILayout.LabelField("Atajo Rápido:", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Ctrl + Shift + P = Guardar rápido en ruta correcta");
        EditorGUILayout.LabelField("Ctrl + Shift + U = Guardar como UI");
        EditorGUILayout.LabelField("Ctrl + Shift + G = Guardar como GameObject");
        EditorGUILayout.EndVertical();
    }

    /// <summary>
    /// Verifica si el GameObject tiene un RectTransform
    /// </summary>
    private bool HasRectTransform(GameObject obj)
    {
        return obj.GetComponent<RectTransform>() != null;
    }

    /// <summary>
    /// Obtiene la ruta de guardado según el tipo de objeto
    /// </summary>
    private string GetSavePath(GameObject obj)
    {
        if (obj == null) return PREFABS_PATH;
        return HasRectTransform(obj) ? UI_PREFABS_PATH : PREFABS_PATH;
    }

    /// <summary>
    /// Método principal para crear el prefab
    /// </summary>
    private void CreatePrefab()
    {
        if (selectedObject == null)
        {
            EditorUtility.DisplayDialog("Error", "Selecciona un objeto primero.", "OK");
            return;
        }

        if (string.IsNullOrEmpty(prefabName))
        {
            EditorUtility.DisplayDialog("Error", "Ingresa un nombre para el prefab.", "OK");
            return;
        }

        // Asegurar que el nombre termine en .prefab
        if (!prefabName.EndsWith(".prefab"))
        {
            prefabName += ".prefab";
        }

        string savePath = GetSavePath(selectedObject);
        string fullPath = savePath + prefabName;
        string uniquePath = AssetDatabase.GenerateUniqueAssetPath(fullPath);

        GameObject prefab = PrefabUtility.SaveAsPrefabAsset(selectedObject, uniquePath);

        if (prefab != null)
        {
            Debug.Log($"Prefab creado: {uniquePath}");
            Selection.activeObject = prefab;
            EditorGUIUtility.PingObject(prefab);
        }
    }
}

public class PrefabCreatorQuickActions
{
    /// <summary>
    /// Método rápido para crear prefab detectando automáticamente el tipo
    /// </summary>
    [MenuItem("B_Extensions/Hierarchy Extension/Create Prefab Quick Save %&#p")]
    public static void QuickCreatePrefab()
    {
        GameObject selectedObject = Selection.activeGameObject;

        if (selectedObject == null)
        {
            EditorUtility.DisplayDialog(
                "Error",
                "Selecciona un objeto en la Hierarchy primero.",
                "OK"
            );
            return;
        }

        CreatePrefabForObject(selectedObject);
    }

    /// <summary>
    /// Método interno para crear el prefab
    /// </summary>
    private static void CreatePrefabForObject(
        GameObject selectedObject,
        bool forceUIPath = false,
        bool forceGameObjectPath = false
    )
    {
        // Rutas
        const string prefabsPath = "Assets/Level/Prefabs/";
        const string uiPrefabsPath = "Assets/Level/Prefabs/UI/";

        // Determinar la ruta según el tipo de objeto
        string savePath;
        bool isUI = selectedObject.GetComponent<RectTransform>() != null;

        if (forceUIPath)
        {
            savePath = uiPrefabsPath;
        }
        else if (forceGameObjectPath)
        {
            savePath = prefabsPath;
        }
        else
        {
            savePath = isUI ? uiPrefabsPath : prefabsPath;
        }

        // Crear carpetas si no existen
        CreateFolderIfNeeded("Assets/Level");
        CreateFolderIfNeeded("Assets/Level/Prefabs");
        CreateFolderIfNeeded("Assets/Level/Prefabs/UI");

        // Generar nombre único
        string prefabName = selectedObject.name + ".prefab";
        string fullPath = savePath + prefabName;
        string uniquePath = AssetDatabase.GenerateUniqueAssetPath(fullPath);

        // Crear el prefab
        GameObject prefab = PrefabUtility.SaveAsPrefabAsset(selectedObject, uniquePath);

        if (prefab != null)
        {
            string icon = isUI ? "📱" : "🎮";
            Debug.Log($"{icon} Prefab creado: {uniquePath}");
            Selection.activeObject = prefab;
            EditorGUIUtility.PingObject(prefab);
        }
        else
        {
            EditorUtility.DisplayDialog(
                "Error",
                "No se pudo crear el prefab.",
                "OK"
            );
        }
    }

    /// <summary>
    /// Crea una carpeta si no existe
    /// </summary>
    private static void CreateFolderIfNeeded(string path)
    {
        if (!AssetDatabase.IsValidFolder(path))
        {
            // Extraer el path padre y el nombre de la carpeta
            string parentPath = System.IO.Path.GetDirectoryName(path);
            string folderName = System.IO.Path.GetFileName(path);

            if (!string.IsNullOrEmpty(parentPath) && !string.IsNullOrEmpty(folderName))
            {
                AssetDatabase.CreateFolder(parentPath, folderName);
            }
        }
    }
}