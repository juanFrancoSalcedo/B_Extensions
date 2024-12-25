using System.IO;
using UnityEngine;

public class TestDirectiva : MonoBehaviour
{

    private void Start()
    {

        string scriptDirectiva = "Assets/Plugins/Demigiant/DOTweenPro/DOTweenPro.dll";

        if (File.Exists(scriptDirectiva))
        {
            print("Mostrar");
        }

#if ANIMA_DOTWEEN_PRO
      Debug.Log("¡El archivo dll existe en el proyecto!");
#else
        Debug.Log("El archivo dll no está presente.");
#endif
    }
}
