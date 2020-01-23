using UnityEngine;

public class ScriptsStorage : MonoBehaviour
{
    public static ScriptsStorage instance;

    [Header("Linqs")]
    public CameraMovement cameraMovement;
    public ButtonsUser buttonsUser;
    public TargetContainer targetContainer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
