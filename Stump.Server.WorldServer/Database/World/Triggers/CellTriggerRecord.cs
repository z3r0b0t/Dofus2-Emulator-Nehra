using Stump.Core.Reflection;
using Stump.DofusProtocol.Enums;
using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;
using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Game.Conditions;
using Stump.Server.WorldServer.Game.Maps;
using Stump.Server.WorldServer.Game.Maps.Cells;
using Stump.Server.WorldServer.Game.Maps.Cells.Triggers;

namespace Stump.Server.WorldServer.Database.World.Triggers
{
	[TableName("world_maps_triggers")]
	public class CellTriggerRecord : ParameterizableRecord, IAutoGeneratedRecord
	{
		private short m_cellId;
		private string m_condition;
		private ConditionExpression m_conditionExpression;
		private int m_mapId;
		private bool m_mustRefreshPosition;
		private ObjectPosition m_position;
		public int Id
		{
			get;
			set;
		}
		public string Type
		{
			get;
			set;
		}
		public short CellId
		{
			get
			{
				return this.m_cellId;
			}
			set
			{
				this.m_cellId = value;
				this.m_mustRefreshPosition = true;
			}
		}
		public int MapId
		{
			get
			{
				return this.m_mapId;
			}
			set
			{
				this.m_mapId = value;
				this.m_mustRefreshPosition = true;
			}
		}
		public CellTriggerType TriggerType
		{
			get;
			set;
		}
		[NullString]
		public string Condition
		{
			get
			{
				return this.m_condition;
			}
			set
			{
				this.m_condition = value;
				this.m_conditionExpression = null;
			}
		}
		[Ignore]
		public ConditionExpression ConditionExpression
		{
			get
			{
				ConditionExpression result;
				if (string.IsNullOrEmpty(this.Condition) || this.Condition == "null")
				{
					result = null;
				}
				else
				{
					ConditionExpression arg_47_0;
					if ((arg_47_0 = this.m_conditionExpression) == null)
					{
						arg_47_0 = (this.m_conditionExpression = ConditionExpression.Parse(this.Condition));
					}
					result = arg_47_0;
				}
				return result;
			}
			set
			{
				this.m_conditionExpression = value;
				this.Condition = value.ToString();
			}
		}
		private void RefreshPosition()
		{
            Map map = Singleton<Game.World>.Instance.GetMap(this.MapId);
			if (map == null)
			{
				throw new System.Exception(string.Format("Cannot load CellTrigger id={0}, map {1} isn't found", this.Id, this.MapId));
			}
			Cell cell = map.Cells[(int)this.CellId];
			this.m_position = new ObjectPosition(map, cell, DirectionsEnum.DIRECTION_EAST);
		}
		public ObjectPosition GetPosition()
		{
			if (this.m_position == null || this.m_mustRefreshPosition)
			{
				this.RefreshPosition();
			}
			this.m_mustRefreshPosition = false;
			return this.m_position;
		}
		public CellTrigger GenerateTrigger()
		{
			return Singleton<DiscriminatorManager<CellTrigger>>.Instance.Generate<CellTriggerRecord>(this.Type, this);
		}
	}
}
