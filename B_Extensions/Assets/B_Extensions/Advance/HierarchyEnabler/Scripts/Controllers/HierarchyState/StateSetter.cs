using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

<<<<<<<< HEAD:B_Extensions/Assets/B_Extension/Advance/HierarchyEnabler/Scripts/Controllers/HierarchyState/StateSetter.cs
namespace B_Extensions.HierarchyStates
========
namespace B_extensions.HierarchyStates
>>>>>>>> 9c4bc29519a438132e66a381b77b02e5aa7eca6e:B_Extensions/Assets/B_Extensions/Advance/HierarchyEnabler/Scripts/Controllers/HierarchyState/StateSetter.cs
{
    [DisallowMultipleComponent]
    public class StateSetter : MonoBehaviour
    {
        public bool stateEnable = false;
        [SerializeField] private float timeDelay = 0f;
        [SerializeField] public StateReference reference = null;
        public static event System.Action<StateReference> OnEnabled;
        bool lastState = false;
        private void OnValidate()
        {
            #if UNITY_EDITOR
            if (reference == null)
                reference = new StateReference();
            if (string.IsNullOrEmpty(reference.UniqueId) ||
                string.IsNullOrEmpty(reference.sceneName) ||
                reference.handler == null)
            {
                reference.UpdateElementToken();
                reference.UpdateElementScene();
                reference.UpdateElementHandler(this);
                
                    EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
            }
            #endif
        }

        private void OnEnable()
        {
            if (!stateEnable)
                OnEnabled?.Invoke(reference);
        }

        public void EnableOnHierarchy() => gameObject.SetActive(stateEnable);

        public void SetActive(bool active)
        {
            if (active)
                gameObject.SetActive(active);
            else
                SetActiveFalse();
        }

        private void SetActiveFalse()
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

    public class StateHierachyEnabler 
    {

        public static void SearchAndEnableInParent(Transform parent) 
        {
            for (int i = 0; i < parent.childCount; i++)
            {

            }
        }
    }
}
