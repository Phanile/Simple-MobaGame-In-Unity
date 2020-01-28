using UnityEngine;
using UnityEngine.UI;

public class Mouse : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _distance;
    [SerializeField] private MouseState _state;

    [Header("Layers")]
    [SerializeField] private LayerMask _selectableMask;
    [SerializeField] private LayerMask _groundMask;

    [Header("Linqs")]
    [SerializeField] private CameraMovement _camMovement;
    [SerializeField] private TargetContainer _targetContainer;
    [SerializeField] private MoveParticleSpawner _moveParticleSpawner;

    private Vector3 _movePoint;

    [Header("Cursor Textures")]
    [SerializeField] private Texture2D _normal;
    [SerializeField] private Texture2D _spellUses;

    [Header("SpellData")]
    public SpellData data;

    private void Start()
    {
        Cursor.visible = true;
        SetCursor(_normal);
    }

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
            if (Input.GetMouseButtonDown(0))
            {
                if (_state == MouseState.spellUses)
                {
                    _movePoint = hit.point;
                    if (_targetContainer.Target != null)
                    {
                        if (data.activeSpellType == ActiveSpellType.notAiming)
                        {
                            if (_targetContainer.Target.CompareTag("Player"))
                            {
                                if (_targetContainer.Target.GetComponent<ISpellUser>().TryToUseSpellTo(_movePoint, data))
                                {
                                    _targetContainer.Target.GetComponent<ISpellUser>().UseSpellTo(_movePoint, data);
                                    AfterSpellEndClick();
                                }
                                else
                                {
                                    _targetContainer.Target.GetComponent<IMovable>().StartMoveToUseSpeellTo(_movePoint, data);
                                    AfterSpellEndClick();
                                }
                            }
                        }
                    }
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                if (_state == MouseState.normal)
                {
                    _movePoint = hit.point;
                    if (_targetContainer.Target != null)
                    {
                        _targetContainer.Target.GetComponent<IMovable>().Move(_movePoint);
                        _targetContainer.Target.GetComponent<IMovable>().Rotate(_movePoint);
                        _moveParticleSpawner.SpawnParticle(_movePoint);
                    }
                }
                if (_state == MouseState.spellUses)
                {
                    AfterSpellEndClick();
                }
            }
        }
    }

    private void AimTarget(ITarget target)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_state == MouseState.normal)
            {
                target.Select();
                return;
            }
            if (_state == MouseState.spellUses)
            {
                if (data.activeSpellType != ActiveSpellType.selfUse)
                {
                    if (_targetContainer.Target != null)
                    {
                        if (_targetContainer.Target.CompareTag("Player"))
                        {
                            if (target.transform.gameObject.CompareTag("Player"))
                            {
                                return;
                            }
                            if (_targetContainer.Target.GetComponent<ISpellUser>().TryToUseSpellOnTarget(target, data))
                            {
                                _targetContainer.Target.GetComponent<ISpellUser>().UseSpellOn(target, data);
                                AfterSpellEndClick();
                            }
                            else
                            {
                                _targetContainer.Target.GetComponent<IMovable>().StartMoveToUseSpeellOnTarget(target, data);
                                AfterSpellEndClick();
                            }
                        }
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (target.transform.CompareTag("Enemy"))
            {
                if (_targetContainer.Target != null)
                {
                    if (_targetContainer.Target.CompareTag("Player"))
                    {
                        if (_targetContainer.Target.GetComponent<ITarget>().TryToHitTarget(target))
                        {
                            _targetContainer.Target.GetComponent<ITarget>().Attack(target);
                        }
                        else
                        {
                            _targetContainer.Target.GetComponent<IMovable>().StartMoveToTarget(target);
                        }
                    }
                }
                else
                {
                    return;
                }
            }
        }
        target.OnAimAtTarget();
    }

    private void SetCursor(Texture2D image)
    {
        Cursor.SetCursor(image, Vector2.zero, CursorMode.Auto);
    }

    public void PrepareToUseActiveSkill()
    {
        SetCursor(_spellUses);
        _state = MouseState.spellUses;
    }

    public void SetData(SpellData data)
    {
        this.data = data;
    }

    public void ClearData()
    {
        data = null;
    }

    public void AfterSpellEndClick()
    {
        ClearData();
        _state = MouseState.normal;
        SetCursor(_normal);
    }
}
public enum MouseState
{
    normal,
    spellUses
}

