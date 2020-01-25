using UnityEngine;

public class TargetSelector : MonoBehaviour
{
    [Header("Linqs")]
    [SerializeField] private TargetContainer _targetContainer;

    [Header("SelectMaterial")]
    [SerializeField] private Material _material;

    [Header("Other")]
    private ITarget _previousTarget;

    public void SelectTarget(ITarget target)
    {
        if (target == _previousTarget)
        {
            return;
        }
        else
        {
            DeselectTarget(_previousTarget);
            target.transform.gameObject.AddComponent<LineRenderer>();
            target.transform.gameObject.AddComponent<TargetLine>();
            target.transform.gameObject.GetComponent<LineRenderer>().startWidth = 0.05f;
            target.transform.gameObject.GetComponent<LineRenderer>().material = _material;
            _previousTarget = target;
        }
    }

    public void DeselectTarget(ITarget target)
    {
        if (_previousTarget == null)
        {
            return;
        }
        if (target.transform.gameObject.GetComponent<TargetLine>() != null && target.transform.gameObject.GetComponent<LineRenderer>() != null)
        {
            Destroy(target.transform.gameObject.GetComponent<LineRenderer>());
            Destroy(target.transform.gameObject.GetComponent<TargetLine>());
        }
    }
}
