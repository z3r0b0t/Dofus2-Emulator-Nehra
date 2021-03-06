using Stump.Core.Reflection;
using Stump.DofusProtocol.Enums;
using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Actors.Look;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Npcs;
using Stump.Server.WorldServer.Game.Maps;
using Stump.Server.WorldServer.Game.Maps.Cells;

namespace Stump.Server.WorldServer.Database.Npcs
{
	[TableName("npcs_spawns")]
	public class NpcSpawn : IAutoGeneratedRecord
	{
		private ActorLook m_entityLook;
		private string m_lookAsString;
		private NpcTemplate m_template;
		public uint Id
		{
			get;
			set;
		}
		public int NpcId
		{
			get;
			set;
		}
		[Ignore]
		public NpcTemplate Template
		{
			get
			{
				NpcTemplate arg_23_0;
				if ((arg_23_0 = this.m_template) == null)
				{
					arg_23_0 = (this.m_template = Singleton<NpcManager>.Instance.GetNpcTemplate(this.NpcId));
				}
				return arg_23_0;
			}
			set
			{
				this.m_template = value;
				this.NpcId = value.Id;
			}
		}
		public int MapId
		{
			get;
			set;
		}
		public int CellId
		{
			get;
			set;
		}
		public DirectionsEnum Direction
		{
			get;
			set;
		}
		private string LookAsString
		{
			get
			{
				string result;
				if (this.m_entityLook == null)
				{
					result = string.Empty;
				}
				else
				{
					if (string.IsNullOrEmpty(this.m_lookAsString))
					{
						this.m_lookAsString = this.Look.ToString();
					}
					result = this.m_lookAsString;
				}
				return result;
			}
			set
			{
				this.m_lookAsString = value;
				if (value != null)
				{
					this.m_entityLook = ActorLook.Parse(this.m_lookAsString);
				}
			}
		}
		[Ignore]
		public ActorLook Look
		{
			get
			{
				return this.m_entityLook ?? this.Template.Look;
			}
			set
			{
				this.m_entityLook = value;
				if (value != null)
				{
					this.m_lookAsString = value.ToString();
				}
			}
		}
		public ObjectPosition GetPosition()
		{
            Map map = Singleton<Game.World>.Instance.GetMap(this.MapId);
			if (map == null)
			{
				throw new System.Exception(string.Format("Cannot load NpcSpawn id={0}, map {1} isn't found", this.Id, this.MapId));
			}
			Cell cell = map.Cells[this.CellId];
			return new ObjectPosition(map, cell, this.Direction);
		}
	}
}
