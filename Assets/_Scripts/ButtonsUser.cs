using UnityEngine;

public class ButtonsUser : MonoBehaviour
{
    [Header("Linqs")]
    [SerializeField] private Character _character;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _character.StopMotion();
        }
    }
}
