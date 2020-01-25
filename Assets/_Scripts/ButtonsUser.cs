using UnityEngine;

public class ButtonsUser : MonoBehaviour
{
    [Header("Linqs")]
    [SerializeField] private Character _character;
    [SerializeField] private UnityEngine.UI.Button[] _buttons;

    [Header("Datas")]
    [SerializeField] private SpellData[] _datas;

    private void Update()
    {
        CheckSpells();
        if (Input.GetKeyDown(KeyCode.S))
        {
            _character.StopMotion();
        }
    }

    private void CheckSpells()
    {
        for (int i = 0; i < _datas.Length; i++)
        {
            if (Input.GetKeyDown(_datas[i].keyCode))
            {
                _buttons[i].onClick.Invoke();
            }
        }
    }
}
