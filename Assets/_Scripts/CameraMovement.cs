using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _cameraRoot;

    [Header("Targets")]
    [SerializeField] private GameObject _target;
    public GameObject Target
    {
        get
        {
            return _target;
        }
        set
        {
            if (value != null)
            _target = value;
        }
    }


    private void FixedUpdate()
    {
       // if (Target != null)
       // _cameraRoot.transform.position = Vector3.Lerp(_cameraRoot.transform.position, _target.transform.position, Time.deltaTime * _speed);
    }
}
