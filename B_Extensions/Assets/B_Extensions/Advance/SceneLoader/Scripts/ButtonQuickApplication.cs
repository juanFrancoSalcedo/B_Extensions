using B_extensions;
using B_extensions.SceneLoader;

public class ButtonQuickApplication: BaseButtonAttendant
{
    private void Start() => buttonComponent.onClick.AddListener(()=>SceneLoader.Instance.Quit());
}
