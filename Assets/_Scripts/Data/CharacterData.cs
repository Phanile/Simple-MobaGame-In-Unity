using UnityEngine;
[CreateAssetMenu(menuName = "CharacterData")]
public class CharacterData : ScriptableObject
{
    [Header("Other")]
    public string nick;

    [Header("Damage")]
    public float handDamageAtStart;
    public float handDamage;

    [Header("MoveSpeed")]
    public float moveSpeedAtStart;
    public float moveSpeed;

    [Header("AttackRate")]
    public float attackRateOnStart;
    public float attackRate;

    [Header("AttackRaduis")]
    public float attackRadius;

    [Header("RotateSpeed")]
    public float rotateSpeed;

    [Header("Stats")]
    public int manaAtStart;
    public int mana;
    public int healthAtStart;
    public int health;
}
