using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("Datas")]
    [SerializeField] private CreepData _data;

    [Header("UI")]
    [SerializeField] private Image _fill;

    [Header("Variables")]
    [SerializeField] private float _fillSpeed = 3;
    public float currentHealth;
    public float maxHealth;

    private void Start()
    {
        Initialize(_data);
    }

    private void LateUpdate()
    {
        if (_data != null)
        {
            currentHealth = _data.health;
            _fill.fillAmount = Mathf.Lerp(_fill.fillAmount, currentHealth / maxHealth, Time.deltaTime * _fillSpeed);
            transform.LookAt(Camera.main.transform);
        }
    }

    public void Initialize(CreepData data)
    {
        _data = data;
        maxHealth = _data.maxHealth;
        currentHealth = _data.health;
        _fill.fillAmount = currentHealth / maxHealth;
    }   
}