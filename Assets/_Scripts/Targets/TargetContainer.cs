using UnityEngine;

public class TargetContainer : MonoBehaviour
{
    [Header("Linqs")]
    [SerializeField] private TargetSelector _targetSelector;

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
            {
                _target = value;
                _targetSelector.SelectTarget(value.GetComponent<ITarget>());
            }
        }
    }
}
