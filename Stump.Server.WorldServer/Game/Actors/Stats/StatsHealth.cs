using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Game.Actors.Interfaces;
using System;
namespace Stump.Server.WorldServer.Game.Actors.Stats
{
	public class StatsHealth : StatsData
	{
		private int m_damageTaken;
		private int m_realDamageTaken;
		private int m_permanentDamages;
		public override int Base
		{
			get
			{
				return this.ValueBase;
			}
			set
			{
				this.ValueBase = value;
				this.AdjustTakenDamage();
				this.OnModified();
			}
		}
		public override int Equiped
		{
			get
			{
				return this.ValueEquiped;
			}
			set
			{
				this.ValueEquiped = value;
				this.AdjustTakenDamage();
				this.OnModified();
			}
		}
		public override int Given
		{
			get
			{
				return this.ValueGiven;
			}
			set
			{
				this.ValueGiven = value;
				this.AdjustTakenDamage();
				this.OnModified();
			}
		}
		public override int Context
		{
			get
			{
				return this.ValueContext;
			}
			set
			{
				this.ValueContext = value;
				this.AdjustTakenDamage();
				this.OnModified();
			}
		}
		public int DamageTaken
		{
			get
			{
				return this.m_damageTaken;
			}
			set
			{
				this.m_realDamageTaken = value;
				this.m_damageTaken = ((value > this.TotalMax) ? this.TotalMax : value);
				this.OnModified();
			}
		}
		public int PermanentDamages
		{
			get
			{
				return this.m_permanentDamages;
			}
			set
			{
				if (this.TotalMax - value < 0)
				{
					this.m_permanentDamages = this.Base + this.Equiped + this.Given + this.Context + ((base.Owner.Stats != null) ? base.Owner.Stats[PlayerFields.Vitality].Total : 0) - 1;
				}
				else
				{
					this.m_permanentDamages = value;
				}
				if (this.TotalSafe > this.TotalMax)
				{
					this.DamageTaken += this.TotalSafe - this.TotalMax;
				}
				this.OnModified();
			}
		}
		public override int Total
		{
			get
			{
				return this.TotalSafe;
			}
		}
		public override int TotalSafe
		{
			get
			{
				int num = this.TotalMax - this.DamageTaken;
				return (num < 0) ? 0 : num;
			}
		}
		public int TotalMax
		{
			get
			{
				int num = this.Base + this.Equiped + this.Given + this.Context + ((base.Owner.Stats != null) ? base.Owner.Stats[PlayerFields.Vitality].Total : 0) - this.PermanentDamages;
				return (num < 0) ? 0 : num;
			}
		}
		public StatsHealth(IStatsOwner owner, int valueBase, int damageTaken) : base(owner, PlayerFields.Health, valueBase, null)
		{
			this.DamageTaken = damageTaken;
			base.Owner.Stats[PlayerFields.Vitality].Modified += new Action<StatsData, int>(this.OnVitalityModified);
		}
		private void OnVitalityModified(StatsData vitality, int value)
		{
			this.AdjustTakenDamage();
		}
		private void AdjustTakenDamage()
		{
			if (this.m_damageTaken > this.TotalMax)
			{
				this.m_realDamageTaken = this.m_damageTaken;
				this.m_damageTaken = (int)((short)this.TotalMax);
			}
			else
			{
				if (this.m_realDamageTaken > this.m_damageTaken)
				{
					this.m_damageTaken = this.m_realDamageTaken;
				}
			}
		}
	}
}
