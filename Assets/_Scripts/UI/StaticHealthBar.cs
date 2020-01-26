using UnityEngine;
using UnityEngine.UI;

public class StaticHealthBar : MonoBehaviour
{
    [Header("Other")]
    [SerializeField] private CharacterData _data;

    [Header("UI")]
    [SerializeField] private Image _fill;

    [Header("Variables")]
    [SerializeField] private float _fillSpeed;
    public float currentHealth;
    public float maxHealth;

    private void Start()
    {
        Initialize(_data);
    }

    private void Update()
    {
        if (_data != null)
        {
            currentHealth = _data.health;
            _fill.fillAmount = Mathf.Lerp(_fill.fillAmount, currentHealth / maxHealth, Time.deltaTime * _fillSpeed);
        }
    }

    public void Initialize(CharacterData data)
    {
        _data = data;
        maxHealth = _data.maxHealth;
        currentHealth = _data.health;
        _fill.fillAmount = currentHealth / maxHealth;
    }
}
