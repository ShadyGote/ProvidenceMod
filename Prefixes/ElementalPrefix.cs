using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using static ProvidenceMod.ProvidenceUtils;

namespace ProvidenceMod.Prefixes
{
  public class ElementalPrefix : ModPrefix
  {
    private readonly float _power;
    private readonly byte _element;
    public override PrefixCategory Category => PrefixCategory.AnyWeapon;
    public override float RollChance(Item item) => 2.5f;
    public override bool CanRoll(Item item) => item.Providence().element == _element;

    public ElementalPrefix() { }
    public ElementalPrefix(byte power, byte element) { _power = power; _element = element; }
    public override bool Autoload(ref string name)
    {
      if (!base.Autoload(ref name)) return false;

      mod.AddPrefix("Burning", new ElementalPrefix(10, (byte)ElementID.Fire));
      mod.AddPrefix("Scorching", new ElementalPrefix(20, (byte)ElementID.Fire));
      mod.AddPrefix("Incinerating", new ElementalPrefix(30, (byte)ElementID.Fire));

      mod.AddPrefix("Chilling", new ElementalPrefix(10, (byte)ElementID.Ice));
      mod.AddPrefix("Freezing", new ElementalPrefix(20, (byte)ElementID.Ice));
      mod.AddPrefix("Permafrosting", new ElementalPrefix(30, (byte)ElementID.Ice));

      mod.AddPrefix("Sparking", new ElementalPrefix(10, (byte)ElementID.Lightning));
      mod.AddPrefix("Shocking", new ElementalPrefix(20, (byte)ElementID.Lightning));
      mod.AddPrefix("Lightning", new ElementalPrefix(30, (byte)ElementID.Lightning));

      mod.AddPrefix("Dampening", new ElementalPrefix(10, (byte)ElementID.Water));
      mod.AddPrefix("Dousing", new ElementalPrefix(20, (byte)ElementID.Water));
      mod.AddPrefix("Drenching", new ElementalPrefix(30, (byte)ElementID.Water));

      mod.AddPrefix("Cracking", new ElementalPrefix(10, (byte)ElementID.Earth));
      mod.AddPrefix("Crumbling", new ElementalPrefix(20, (byte)ElementID.Earth));
      mod.AddPrefix("Shattering", new ElementalPrefix(30, (byte)ElementID.Earth));

      mod.AddPrefix("Gale", new ElementalPrefix(10, (byte)ElementID.Air));
      mod.AddPrefix("Zephyr", new ElementalPrefix(20, (byte)ElementID.Air));
      mod.AddPrefix("Tempest", new ElementalPrefix(30, (byte)ElementID.Air));

      mod.AddPrefix("Pious", new ElementalPrefix(10, (byte)ElementID.Order));
      mod.AddPrefix("Cleansing", new ElementalPrefix(20, (byte)ElementID.Order));
      mod.AddPrefix("Purging", new ElementalPrefix(30, (byte)ElementID.Order));

      mod.AddPrefix("Afflicting", new ElementalPrefix(10, (byte)ElementID.Chaos));
      mod.AddPrefix("Pestilent", new ElementalPrefix(20, (byte)ElementID.Chaos));
      mod.AddPrefix("Abhorrent", new ElementalPrefix(30, (byte)ElementID.Chaos));
      return false;
    }
    public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
    {
      damageMult += 0.01f * _power;
    }
  }
}