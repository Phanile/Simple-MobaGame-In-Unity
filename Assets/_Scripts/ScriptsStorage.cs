using UnityEngine;

public class ScriptsStorage : MonoBehaviour
{
    public static ScriptsStorage instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public CameraMovement cameraMovement;
}
