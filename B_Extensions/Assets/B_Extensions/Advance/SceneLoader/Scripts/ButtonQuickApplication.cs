<<<<<<<< HEAD:B_Extensions/Assets/B_Extension/Advance/SceneLoader/Scripts/ButtonQuickApplication.cs
﻿using B_Extensions;
using B_Extensions.SceneLoader;
========
﻿using B_extensions;
using B_extensions.SceneLoader;
>>>>>>>> 9c4bc29519a438132e66a381b77b02e5aa7eca6e:B_Extensions/Assets/B_Extensions/Advance/SceneLoader/Scripts/ButtonQuickApplication.cs

public class ButtonQuickApplication: BaseButtonAttendant
{
    private void Start() => buttonComponent.onClick.AddListener(()=>SceneLoader.Instance.Quit());
}
