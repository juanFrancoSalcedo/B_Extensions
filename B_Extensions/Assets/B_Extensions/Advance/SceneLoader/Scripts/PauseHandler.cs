using UnityEngine;

<<<<<<<< HEAD:B_Extensions/Assets/B_Extension/Advance/SceneLoader/Scripts/PauseHandler.cs
namespace B_Extensions.SceneLoader
========
namespace B_extensions.SceneLoader
>>>>>>>> 9c4bc29519a438132e66a381b77b02e5aa7eca6e:B_Extensions/Assets/B_Extensions/Advance/SceneLoader/Scripts/PauseHandler.cs
{
    public class PauseHandler
    {
        public static event System.Action<bool> OnPaused;

        public void Pause(bool pause)
        {
            Time.timeScale = (pause) ? 0 : 1;
            OnPaused?.Invoke(IsPaused);
        }

        public void Pause(float time)
        {
            Time.timeScale = time;
            OnPaused?.Invoke(IsPaused);
        }

        public void Pause()
        {
            Time.timeScale = IsPaused ?1:0;
            OnPaused?.Invoke(IsPaused);
        }

        public bool IsPaused => Time.time == 0;
    }
}