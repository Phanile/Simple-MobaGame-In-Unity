using UnityEngine;

[CreateAssetMenu(menuName = "SpellData")]
public class SpellData : ScriptableObject
{
    [Header("UI")]
    public UnityEngine.UI.Image spellIcon;

    [Header("Types")]
    public SpellType type;
    public ActiveSpellType activeSpellType;

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
    global
}

