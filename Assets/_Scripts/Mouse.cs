using UnityEngine;

public class Mouse : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _distance;
    [SerializeField] private LayerMask _selectableMask;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private CameraMovement _camMovement;
    [SerializeField] private TargetContainer _targetContainer;

    private Vector3 _movePoint;

    private void Update()
    {
        RayCast();
    }

    private void RayCast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _distance, _selectableMask))
        {
            var target = hit.transform.GetComponent<ITarget>();
            if (target != null)
            {
                AimTarget(target);
                return;
            }
        }

        if (Physics.Raycast(ray, out hit, _distance, _groundMask))
        {
            if (Input.GetMouseButtonDown(1))
            {
                _movePoint = hit.point;
                if (_targetContainer.Target != null)
                {
                    _targetContainer.Target.GetComponent<IMovable>().Move(_movePoint);
                    _targetContainer.Target.GetComponent<IMovable>().Rotate(_movePoint);
                }
            }
        }
    }

    private void AimTarget(ITarget target)
    {
        if (Input.GetMouseButtonDown(0))
        {
             target.Select();
             return; 
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (target.transform.CompareTag("Enemy"))
            {
                _targetContainer.Enemy = target.transform.gameObject;
            }
            if (_targetContainer.Enemy != null && _targetContainer.Enemy.GetComponent<ITarget>() == target)
            {
                if (_targetContainer.Target == null)
                {
                    return;
                }
                else
                {
                    if (_targetContainer.Target.GetComponent<ITarget>().TryToHitTarget(target))
                    {
                        _targetContainer.Target.GetComponent<ITarget>().Attack(target);
                    }
                    else
                    {
                        _targetContainer.Target.GetComponent<IMovable>().StartMoveToTarget(_targetContainer.Enemy.GetComponent<ITarget>());
                    }
                }
            }
        }
        target.OnAimAtTarget();
    }
}

