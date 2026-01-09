using UnityEngine;

public class PlayerUISetup : MonoBehaviour
{
    void Start()
    {
        Camera cam = GetComponentInChildren<Camera>();
        Canvas canvas = GetComponentInChildren<Canvas>();

        if (cam && canvas)
        {
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.worldCamera = cam;
        }
    }
}
