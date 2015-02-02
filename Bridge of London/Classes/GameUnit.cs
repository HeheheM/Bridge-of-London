using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;

namespace Bridge_of_London.Classes
{
    internal class GameUnit
    {
        private Obj_AI_Base b;

        public string name
        {
            get { return b.BaseSkinName; }
        }

        public string charName
        {
            get { return b is Obj_AI_Hero ? ((Obj_AI_Hero) b).ChampionName : b.BaseSkinName; }
        }

        public float level
        {
            get { return b is Obj_AI_Hero ? ((Obj_AI_Hero) b).Level : 1; }
        }

        public bool visible
        {
            get { return b.IsVisible; }
        }

        public GameObjectType type
        {
            get { return b.Type; }
        }

        public float x
        {
            get { return b.ServerPosition.X; }
        }

        public float y
        {
            get { return b.ServerPosition.Y; }
        }

        public float z
        {
            get { return b.ServerPosition.Z; }
        }

        public bool isAI
        {
            get { return !b.PlayerControlled; }
        }

        public bool isMe
        {
            get { return b.IsMe; }
        }

        public float buffCount
        {
            get { return b.Buffs.Count(); }
        }

        public float totalDamage
        {
            get { return b.FlatMagicDamageMod + b.FlatPhysicalDamageMod; }
        }

        public bool dead
        {
            get { return b.IsDead; }
        }

        public GameObjectTeam team
        {
            get { return b.Team; }
        }

        public float networkID
        {
            get { return b.NetworkId; }
        }

        public float health
        {
            get { return b.Health; }
        }

        public float maxHealth
        {
            get { return b.MaxHealth; }
        }

        public float mana
        {
            get { return b.Mana; }
        }

        public float maxMana
        {
            get { return b.MaxMana; }
        }

        public bool bInvulnerable
        {
            get { return b.IsInvulnerable; }
        }

        public bool bPhysImune
        {
            get { return b.PhysicalImmune; }
        }

        public bool bMagicImune
        {
            get { return b.MagicImmune; }
        }

        public bool bTargetable
        {
            get { return b.IsTargetable; }
        }

        public bool bTargetableToTeam
        {
            get { return b.IsValidTarget(float.MaxValue, false) && b.IsAlly; }
        }

        public bool controlled
        {
            get { return b.PlayerControlled; }
        }

        public float cdr
        {
            get { return b.FlatCooldownMod; }
        }

        public float critChance
        {
            get { return b.FlatCritChanceMod; }
        }

        public float critDmg
        {
            get { return b.FlatCritDamageMod; }
        }

        public float hpPool
        {
            get { return maxHealth; }
        }

        public float hpRegen
        {
            get { return b.HPRegenRate; }
        }

        public float mpRegen
        {
            get { return b.PARRegenRate; }
        }

        public float attackSpeed
        {
            get { return 1 / b.AttackDelay; }
        }

        public float expBonus
        {
            get { return b.PercentEXPBonus; }
        }

        public float hardness
        {
            get { return 0; }
        }

        public float lifeSteal
        {
            get { return b.PercentLifeStealMod; }
        }

        public float spellVamp
        {
            get { return b.PercentSpellVampMod; }
        }

        public float physReduction
        {
            get { return b.FlatPhysicalReduction; }
        }

        public float magicReduction
        {
            get { return b.FlatMagicReduction; }
        }

        public float armorPen
        {
            get { return b.FlatArmorPenetrationMod; }
        }

        public float magicPen
        {
            get { return b.FlatMagicPenetrationMod; }
        }

        public float armorPenPercent
        {
            get { return b.PercentArmorPenetrationMod; }
        }

        public float magicPenPerecent
        {
            get { return b.PercentMagicPenetrationMod; }
        }

        public float addDamage
        {
            get { return b.FlatPhysicalDamageMod; }
        }

        public float ap
        {
            get { return b.FlatMagicDamageMod; }
        }

        public float damage
        {
            get { return b.FlatPhysicalDamageMod; }
        }

        public float armor
        {
            get { return b.Armor; }
        }

        public float magicArmor
        {
            get { return b.SpellBlock; }
        }

        public float ms
        {
            get { return b.MoveSpeed; }
        }

        public float range
        {
            get { return b.AttackRange; }
        }

        public float gold
        {
            get { return b.Gold; }
        }

        public Position pos
        {
            get { return new Position(b.Position.X, b.Position.Y, b.Position.Z); }
        }

        public Position minBBox
        {
            get { return new Position(b.BBox.Minimum.X, b.BBox.Minimum.Y, b.BBox.Minimum.Z); }
        }

        public Position maxBBox
        {
            get { return new Position(b.BBox.Maximum.X, b.BBox.Maximum.Y, b.BBox.Maximum.Z); }
        }

        public string armorMaterial
        {
            get { return b.ArmorMaterial; }
        }

        public string weaponMaterial
        {
            get { return ""; }
        } // Can't find API in L#

        public float deathTimer
        {
            get { return b.DeathDuration; }
        }

        public bool canAttack
        {
            get { return b.CanAttack; }
        }

        public bool canMove
        {
            get { return b.CanMove; }
        }

        public bool isStealthed
        {
            get { return b.HasBuffOfType(BuffType.Invisibility); }
        }

        public bool isRevealSpecificUnit
        {
            get { return b.CharacterState == GameObjectCharacterState.RevealSpecificUnit; }
        }

        public bool isTaunted
        {
            get { return b.HasBuffOfType(BuffType.Taunt); }
        }

        public bool isCharmed
        {
            get { return b.HasBuffOfType(BuffType.Charm); }
        }

        public bool isFeared
        {
            get { return b.HasBuffOfType(BuffType.Fear); }
        }

        public bool isAsleep
        {
            get { return b.HasBuffOfType(BuffType.Sleep); }
        }

        public bool isNearSight
        {
            get { return b.HasBuffOfType(BuffType.NearSight); }
        }

        public bool isGhosted
        {
            get { return b.CharacterState == GameObjectCharacterState.Ghosted; }
        }

        public bool isNoRender
        {
            get { return b.CharacterState == GameObjectCharacterState.NoRender; }
        }

        public bool isFleeing
        {
            get { return b.CharacterState == GameObjectCharacterState.Fleeing; }
        }

        public bool isForceRenderParticles
        {
            get { return b.CharacterState == GameObjectCharacterState.ForceRenderParticles; }
        }


        public GameUnit(Obj_AI_Base b)
        {
            this.b = b;
        }
    }
}