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

    [Header("EnemyTarget")]
    private GameObject _enemyTarget;
    public GameObject Enemy
    {
        get
        {
            return _enemyTarget;
        }
        set
        {
            if (value != null)
            _enemyTarget = value;
        }
    }

    [Header("SelectMaterial")]
    [SerializeField] private Material _material;

    public void SelectTarget(ITarget target)
    {
        if (Enemy != null)
        {
            DeselectTarget(Enemy.GetComponent<ITarget>());
        }
        if (Target != null)
        {
            DeselectTarget(Target.GetComponent<ITarget>());
        }
        target.transform.gameObject.AddComponent<TargetLine>();
        target.transform.gameObject.GetComponent<LineRenderer>().startWidth = 0.05f;
        target.transform.gameObject.GetComponent<LineRenderer>().material = _material;
    }

    public void DeselectTarget(ITarget target)
    {
        if (target.transform.gameObject.GetComponent<TargetLine>() != null)
        {
            Destroy(target.transform.gameObject.GetComponent<TargetLine>());
            Destroy(target.transform.gameObject.GetComponent<LineRenderer>());
        }
    }
}
