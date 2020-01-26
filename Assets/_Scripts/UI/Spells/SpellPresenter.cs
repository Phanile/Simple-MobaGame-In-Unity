using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class SpellPresenter : MonoBehaviour
{
    [Header("Image")]
    public Sprite spellIcon;

    [Header("BGs")]
    public Image manacostBG;
    public Image keycodeBG;

    [Header("Texts")]
    public TMP_Text manacostText;
    public TMP_Text keycodeText;

    [Header("Data")]
    public SpellData data;

    private void Start()
    {
        Initialize();
    }

    public event UnityAction onSpellUsed;

    public void SetManacostText(string value)
    {
        manacostText.text = value;
    }

    public void SetKeycodeText(string value)
    {
        keycodeText.text = value;
    }

    public void HideBGs()
    {
        manacostBG.gameObject.SetActive(false);
        keycodeBG.gameObject.SetActive(false);
    }

    public void ShowBGs()
    {
        manacostBG.gameObject.SetActive(true);
        keycodeBG.gameObject.SetActive(true);
    }

    public void OnUpdate()
    {
        SetManacostText(data.manaCost.ToString());
        SetKeycodeText(data.keyCode.ToString());
    }

    public void Initialize()
    {
        if (data.type == SpellType.passive)
        {
            HideBGs();
            GetComponent<Button>().interactable = false;
        }
        spellIcon = data.spellIcon;
        GetComponent<Image>().sprite = spellIcon;
        OnUpdate();
    }
}
