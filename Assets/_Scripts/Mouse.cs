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
            AimTarget(target);
        }

        if (Physics.Raycast(ray, out hit, _distance, _groundMask))
        {
            if (Input.GetMouseButtonDown(1))
            {
                _movePoint = hit.point;
                if (_targetContainer.Target != null)
                {
                    _targetContainer.Target.GetComponent<IMovable>().Move(_movePoint);
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
        target.OnAimAtTarget();
    }
}

