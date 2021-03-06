using NLog;
using Stump.Core.Reflection;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.Monsters;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Monsters;
using Stump.Server.WorldServer.Game.Effects.Handlers;
using Stump.Server.WorldServer.Game.Effects.Instances;
using Stump.Server.WorldServer.Game.Spells;
using Stump.Server.WorldServer.Handlers.Actions;
using Stump.DofusProtocol.Enums.HomeMade;

namespace Stump.Server.WorldServer.Game.Effects.Spells.Summon
{
	[EffectHandler(EffectsEnum.Effect_Summon)]
	public class Summon : SpellEffectHandler
	{
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();
		public Summon(EffectDice effect, FightActor caster, Spell spell, Cell targetedCell, bool critical) : base(effect, caster, spell, targetedCell, critical)
		{
		}

        public override bool Apply()
		{
			MonsterGrade monsterGrade = Singleton<MonsterManager>.Instance.GetMonsterGrade(base.Dice.DiceNum, base.Dice.DiceFace);
			bool result;
			if (monsterGrade == null)
			{
				Summon.logger.Error<short, short>("Cannot summon monster {0} grade {1} (not found)", base.Dice.DiceNum, base.Dice.DiceFace);
				result = false;
			}
			else
			{
				if (!base.Caster.CanSummon(base.Dice.DiceNum))
				{
					result = false;
				}
				else
				{
                    bool visible = (monsterGrade.Template.Id == (int)MonsterEnum.SADIDA_TREE) ? false : true; //Need to make a better method
                    SummonedMonster summonedMonster = new SummonedMonster(base.Fight.GetNextContextualId(), base.Caster.Team, base.Caster, monsterGrade, base.TargetedCell, visible);
					ActionsHandler.SendGameActionFightSummonMessage(base.Fight.Clients, summonedMonster);
					base.Caster.AddSummon(summonedMonster);
					base.Caster.Team.AddFighter(summonedMonster);
					result = true;
				}
			}
			return result;
		}
	}
}
