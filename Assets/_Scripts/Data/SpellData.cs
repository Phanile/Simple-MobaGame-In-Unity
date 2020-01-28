using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "SpellData")]
public class SpellData : ScriptableObject
{
    [Header("SpellEvents")]
    public UnityEvent onSpellUp;

    [Header("UI")]
    [SerializeField] public Sprite spellIcon;
    public KeyCode keyCode;

    [Header("Types")]
    public SpellType type;
    public ActiveSpellType activeSpellType;

    [Header("Stats")]
    public bool onCooldown = false;

    [Header("Damage")]
    public int damageAtStart;
    public int damage;

    [Header("Speed")]
    public int speed;

    [Header("Range")]
    public float range;

    [Header("Stats")]
    public int manaCostAtStart;
    public int manaCost;

    public int coolDownAtStart;
    public int coolDown;

    public int levelOfSpell;
    public int maxLevelOfSpell;

    [Header("Spell Prefab")]
    public GameObject spell;

    public void DecreaseCooldown(int value)
    {
        coolDown -= value;
    }

    public void DecreaseManacost(int value)
    {
        manaCost -= value;
    }

    public void IncreaseRange(int value)
    {
        range += value;
    }

    public void IncreaseDamage(int value)
    {
        damage += value;
    }

    public void UpSpell()
    {
        if (levelOfSpell + 1 <= maxLevelOfSpell)
        {
            onSpellUp?.Invoke();
        }
    }

    public void Up()
    {
        levelOfSpell++;
    }

    public void StartCooldown()
    {
        
    }

    private IEnumerator Cooldown()
    {
        onCooldown = true;
        int time = coolDown;
        while (true)
        {
            yield return new WaitForSeconds(1);
            time--;
            if (time == 0)
            {
                yield break;
            }
        }
    }

    public bool TryToClickOnBottonForUse(int mana)
    {
        if (type == SpellType.passive)
        {
            return true;
        }
        if (onCooldown)
        {
            return false;
        }
        if (type == SpellType.active)
        {
            if (manaCost <= mana)
            {
                return true;
            }    
        }
        return false;
    }

    public void ClickOnBottom(int mana)
    {
        if (TryToClickOnBottonForUse(mana))
        {
            if (type == SpellType.passive)
            {
                return;
            }
            var mouse = FindObjectOfType<Mouse>();
            mouse.SetData(this);
            mouse.PrepareToUseActiveSkill();
        }
    }

    public void SpellUseOn(ITarget target)
    {
        Instantiate(spell, target.transform.position + new Vector3(0, 0.5f, 0), spell.transform.rotation);
    }

    public void SpellUseTo(Vector3 pos)
    {
        Instantiate(spell, pos + new Vector3(0, 0.5f, 0), spell.transform.rotation);
    }
}

public enum SpellType
{
    passive,
    active
}

public enum ActiveSpellType
{
    aiming,
    notAiming,
    selfUse,
}

