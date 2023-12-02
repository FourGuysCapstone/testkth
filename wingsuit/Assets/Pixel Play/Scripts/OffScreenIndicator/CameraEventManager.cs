using UnityEngine;

public static class CameraEventManager
{
    public static System.Action<Camera> CameraChanged;

    public static void NotifyCameraChanged(Camera newCamera)
    {
        CameraChanged?.Invoke(newCamera);
    }
}
