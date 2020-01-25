public interface ISpellUser 
{
    void UseSpellOn(ITarget target, SpellData data);
    void UseSpellTo(UnityEngine.Vector3 pos);
    bool TryToUseSpellOnTarget(ITarget target, SpellData data);
}
