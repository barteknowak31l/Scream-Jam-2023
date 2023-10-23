using UnityEngine;

public class ToggleFullscreen : MonoBehaviour
{
    private bool isFullscreen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleFullscreenMode();
        }
    }

    void ToggleFullscreenMode()
    {
        isFullscreen = !isFullscreen;

        if (!isFullscreen)
        {
            Screen.SetResolution(1920, 1080, false); 
        }
        else
        {
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        }
    }
}
