using System.Collections;
using UnityEngine;

namespace B_Extensions.HierarchyStates
{
    /// <summary>
    /// Componente que marca un GameObject como gestionado por el Hierarchy Enabler.
    /// - Unity 6.6+: columna "State" en la Hierarchy (Botón "O" + color) [StateHierarchyColumn].
    ///   - Unity &lt;= 6000.5: botón "O" IMGUI por fila [CustomHierarchy].
    /// - Ctrl+E (menu GameObject/State/Add): añade este componente a la selección.
    /// - Ctrl+Shift+E: restaura todos los StateSetter al estado guardado.
    /// </summary>
    [DisallowMultipleComponent]
    public class StateSetter : MonoBehaviour
    {
        public bool stateEnable = false;
        [SerializeField] private float timeDelay = 0f;

        public void EnableOnHierarchy() => gameObject.SetActive(stateEnable);

        public void SetState(bool active)
        {
            if (active)
                gameObject.SetActive(active);
            else
                SetStateFalse();
        }

        private void SetStateFalse()
        {
            if (gameObject.activeInHierarchy)
                StartCoroutine(WaitDisable());
        }

        private IEnumerator WaitDisable()
        {
            yield return new WaitForSeconds(timeDelay);
            gameObject.SetActive(false);
        }
    }
}
