using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Effects.Handlers;
using Stump.Server.WorldServer.Game.Effects.Instances;
using Stump.Server.WorldServer.Game.Spells;

namespace Stump.Server.WorldServer.Game.Effects.Spells.Buffs
{
	 [EffectHandler(EffectsEnum.Effect_AddRange_136),
     EffectHandler(EffectsEnum.Effect_AddAgility),
     EffectHandler(EffectsEnum.Effect_AddDamageBonus),
     EffectHandler(EffectsEnum.Effect_AddSummonLimit),
     EffectHandler(EffectsEnum.Effect_IncreaseDamage_138), 
     EffectHandler(EffectsEnum.Effect_AddCriticalMiss), 
     EffectHandler(EffectsEnum.Effect_AddDamageBonusPercent), 
     EffectHandler(EffectsEnum.Effect_IncreaseDamage_1054), 
     EffectHandler(EffectsEnum.Effect_AddRange), 
     EffectHandler(EffectsEnum.Effect_AddChance),
     EffectHandler(EffectsEnum.Effect_AddCriticalHit), 
     EffectHandler(EffectsEnum.Effect_AddDamageBonus_121),
     EffectHandler(EffectsEnum.Effect_AddIntelligence),
     EffectHandler(EffectsEnum.Effect_AddVitality),
     EffectHandler(EffectsEnum.Effect_AddWisdom), 
     EffectHandler(EffectsEnum.Effect_AddStrength),
     EffectHandler(EffectsEnum.Effect_AddPhysicalDamage_137),
     EffectHandler(EffectsEnum.Effect_AddLock),
     EffectHandler(EffectsEnum.Effect_AddDodge),
     EffectHandler(EffectsEnum.Effect_AddDamageReflection),
     EffectHandler(EffectsEnum.Effect_AddPhysicalDamage_142),
     EffectHandler(EffectsEnum.Effect_AddPhysicalDamageReduction),
     EffectHandler(EffectsEnum.Effect_AddMagicDamageReduction)]
	public class StatsBuff : SpellEffectHandler
	{
		public StatsBuff(EffectDice effect, FightActor caster, Spell spell, Cell targetedCell, bool critical) : base(effect, caster, spell, targetedCell, critical)
		{
		}
		public override bool Apply()
		{
			bool result;
			foreach (FightActor current in base.GetAffectedActors())
			{
				EffectInteger effectInteger = base.GenerateEffect();
				if (effectInteger == null)
				{
					result = false;
					return result;
				}
				if (this.Effect.Duration > 0)
				{
					base.AddStatBuff(current, effectInteger.Value, StatsBuff.GetEffectCaracteristic(this.Effect.EffectId), true);
				}
			}
			result = true;
			return result;
		}
		public static PlayerFields GetEffectCaracteristic(EffectsEnum effect)
		{
			PlayerFields result;
			if (effect <= EffectsEnum.Effect_AddDamageBonusPercent)
			{
				switch (effect)
				{
				case EffectsEnum.Effect_AddDamageReflection:
					result = PlayerFields.DamageReflection;
					return result;
				case EffectsEnum.Effect_HealHP_108:
				case EffectsEnum.Effect_109:
				case EffectsEnum.Effect_AddHealth:
				case EffectsEnum.Effect_AddAP_111:
				case EffectsEnum.Effect_DoubleDamageOrRestoreHP:
				case EffectsEnum.Effect_AddDamageMultiplicator:
				case EffectsEnum.Effect_SubRange:
				case EffectsEnum.Effect_RegainAP:
					goto IL_11A;
				case EffectsEnum.Effect_AddDamageBonus:
				case EffectsEnum.Effect_AddDamageBonus_121:
					result = PlayerFields.DamageBonus;
					return result;
				case EffectsEnum.Effect_AddCriticalHit:
					result = PlayerFields.CriticalHit;
					return result;
				case EffectsEnum.Effect_AddRange:
					break;
				case EffectsEnum.Effect_AddStrength:
					result = PlayerFields.Strength;
					return result;
				case EffectsEnum.Effect_AddAgility:
					result = PlayerFields.Agility;
					return result;
				case EffectsEnum.Effect_AddCriticalMiss:
					result = PlayerFields.CriticalMiss;
					return result;
				case EffectsEnum.Effect_AddChance:
					result = PlayerFields.Chance;
					return result;
				case EffectsEnum.Effect_AddWisdom:
					result = PlayerFields.Wisdom;
					return result;
				case EffectsEnum.Effect_AddVitality:
					result = PlayerFields.Vitality;
					return result;
				case EffectsEnum.Effect_AddIntelligence:
					result = PlayerFields.Intelligence;
					return result;
				default:
					switch (effect)
					{
					case EffectsEnum.Effect_AddRange_136:
						break;
					case EffectsEnum.Effect_AddPhysicalDamage_137:
					case EffectsEnum.Effect_AddPhysicalDamage_142:
						result = PlayerFields.PhysicalDamage;
						return result;
					case EffectsEnum.Effect_IncreaseDamage_138:
						goto IL_130;
					case EffectsEnum.Effect_RestoreEnergyPoints:
					case EffectsEnum.Effect_SkipTurn:
					case EffectsEnum.Effect_Kill:
						goto IL_11A;
					default:
						if (effect != EffectsEnum.Effect_AddDamageBonusPercent)
						{
							goto IL_11A;
						}
						goto IL_130;
					}
					break;
				}
				result = PlayerFields.Range;
				return result;
			}
			switch (effect)
			{
			case EffectsEnum.Effect_AddSummonLimit:
				result = PlayerFields.SummonLimit;
				return result;
			case EffectsEnum.Effect_AddMagicDamageReduction:
				result = PlayerFields.MagicDamageReduction;
				return result;
			case EffectsEnum.Effect_AddPhysicalDamageReduction:
				result = PlayerFields.PhysicalDamageReduction;
				return result;
			default:
				switch (effect)
				{
				case EffectsEnum.Effect_AddDodge:
					result = PlayerFields.TackleEvade;
					return result;
				case EffectsEnum.Effect_AddLock:
					result = PlayerFields.TackleBlock;
					return result;
				default:
					if (effect == EffectsEnum.Effect_IncreaseDamage_1054)
					{
						goto IL_130;
					}
					break;
				}
				break;
			}
			IL_11A:
			throw new System.Exception(string.Format("'{0}' has no binded caracteristic", effect));
			IL_130:
			result = PlayerFields.DamageBonusPercent;
			return result;
		}
	}
}
