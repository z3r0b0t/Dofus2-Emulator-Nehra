using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;

namespace Stump.Server.WorldServer.Database.Accounts
{
	[TableName("groups_commands")]
	public class UserGroupCommand : IAutoGeneratedRecord
	{
		[PrimaryKey("Id", true)]
		public int Id
		{
			get;
			set;
		}
		public string CommandAlias
		{
			get;
			set;
		}
	}
}
