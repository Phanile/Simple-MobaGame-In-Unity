using UnityEngine;

public class TargetContainer : MonoBehaviour
{
    [Header("TargetInfo")]
    private GameObject _target;
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
}
