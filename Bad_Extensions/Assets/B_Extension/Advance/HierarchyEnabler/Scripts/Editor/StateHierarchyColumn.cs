#if UNITY_6000_6_OR_NEWER
using Unity.Hierarchy;
using Unity.Hierarchy.Editor;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

namespace B_Extensions.HierarchyStates
{
    /// <summary>
    /// Columna "State" de la Hierarchy nueva (UIToolkit) para Unity 6000.6+.
    /// Requiere el módulo builtin de Hierarchy (por defecto referenciado en scripts Editor).
    /// Muestra botón "O" por StateSetter y fondo con colorInHierarchy de ColorHierarchySetter.
    /// </summary>
    internal static class StateHierarchyColumn
    {
        const string k_ColumnId = "GameObject/StateSetter";
        const string k_ToggleUssClass = "state-setter-toggle";
        const string k_ColorUssClass = "state-setter-color-fill";

        [HierarchyViewColumnDescriptor(k_ColumnId)]
        internal static void CreateColumnDesc(HierarchyViewColumnDescriptor desc)
        {
            desc.Title = "State";
            desc.Tooltip = "StateSetter toggle and hierarchy color";
            desc.DefaultPriority = 300;
            desc.DefaultWidth = 30;
            desc.DefaultVisibility = true;
        }

        [HierarchyViewCellDescriptor(k_ColumnId, typeof(HierarchyGameObjectHandler))]
        internal static void CreateGameObjectCellDesc(HierarchyViewCellDescriptor desc)
        {
            desc.BindCell = (HierarchyViewCell cell) =>
            {
                HierarchyGameObjectHandler handler = (HierarchyGameObjectHandler)cell.Handler;
                GameObject gameObject = handler.GetGameObject(cell.Node);
                if (gameObject == null) return;

                StateSetter state = gameObject.GetComponent<StateSetter>();
                ColorHierarchySetter color = gameObject.GetComponent<ColorHierarchySetter>();

                VisualElement fill = cell.Q(className: k_ColorUssClass);
                if (color == null)
                {
                    if (fill != null)
                        fill.RemoveFromHierarchy();
                }
                else
                {
                    if (fill == null)
                    {
                        fill = new VisualElement();
                        fill.AddToClassList(k_ColorUssClass);
                        fill.style.position = Position.Absolute;
                        fill.style.left = 0;
                        fill.style.top = 0;
                        fill.style.right = 0;
                        fill.style.bottom = 0;
                        fill.pickingMode = PickingMode.Ignore;
                        cell.Add(fill);
                    }
                    fill.style.backgroundColor = color.colorInHierarchy;
                    cell.IsDefaultValue = false;
                }

                Button toggle = cell.Q<Button>(className: k_ToggleUssClass);
                if (state == null)
                {
                    if (toggle != null)
                        toggle.RemoveFromHierarchy();
                    return;
                }

                if (toggle == null)
                {
                    Button created = new Button();
                    created.AddToClassList(k_ToggleUssClass);
                    created.style.width = 16;
                    created.style.height = 14;
                    created.style.alignSelf = Align.Center;
                    created.clicked += () =>
                    {
                        StateSetter targetState = created.userData as StateSetter;
                        if (targetState == null) return;

                        Undo.RecordObject(targetState, "Toggle State");
                        targetState.stateEnable = !targetState.stateEnable;
                        targetState.EnableOnHierarchy();
                        EditorUtility.SetDirty(targetState);
                        EditorSceneManager.MarkSceneDirty(targetState.gameObject.scene);

                        created.text = targetState.stateEnable ? "O" : "";
                    };
                    cell.Add(created);
                    toggle = created;
                }

                toggle.userData = state;
                toggle.text = state.stateEnable ? "O" : "";
                toggle.tooltip = state.stateEnable ? "State enabled" : "State disabled";
                cell.IsDefaultValue = false;
            };
        }
    }
}
#endif
