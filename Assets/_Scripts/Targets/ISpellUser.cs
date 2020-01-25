public interface ISpellUser 
{
    void UseSpellOn(ITarget target, SpellData data);
    void UseSpellTo(UnityEngine.Vector3 pos, SpellData data);
    bool TryToUseSpellOnTarget(ITarget target, SpellData data);
    bool TryToUseSpellTo(UnityEngine.Vector3 pos, SpellData data);
}
