using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Game.Actors.Interfaces;

namespace Stump.Server.WorldServer.Game.Actors.Stats
{
	public class StatsInitiative : StatsData
	{
		public override int Base
		{
			get
			{
				return (int)((base.Owner.Stats.Health.Total <= 0) ? 0.0 : ((double)(base.Owner.Stats[PlayerFields.Chance] + base.Owner.Stats[PlayerFields.Intelligence] + base.Owner.Stats[PlayerFields.Agility] + base.Owner.Stats[PlayerFields.Strength]) * ((double)base.Owner.Stats.Health.Total / (double)base.Owner.Stats.Health.TotalMax)));
			}
			set
			{
			}
		}
		public StatsInitiative(IStatsOwner owner, short valueBase) : base(owner, PlayerFields.Initiative, (int)valueBase, null)
		{
		}
	}
}
