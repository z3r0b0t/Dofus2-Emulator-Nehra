using Stump.Core.Reflection;
using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;
using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Database.Npcs.Actions;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Npcs;
using Stump.Server.WorldServer.Game.Conditions;

namespace Stump.Server.WorldServer.Database.Npcs
{
	[TableName("npcs_actions")]
	public class NpcActionRecord : ParameterizableRecord, IAutoGeneratedRecord
	{
		private string m_condition;
		private ConditionExpression m_conditionExpression;
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
		public string Type
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
		public NpcActionDatabase GenerateAction()
		{
			return Singleton<DiscriminatorManager<NpcActionDatabase>>.Instance.Generate<NpcActionRecord>(this.Type, this);
		}
	}
}
