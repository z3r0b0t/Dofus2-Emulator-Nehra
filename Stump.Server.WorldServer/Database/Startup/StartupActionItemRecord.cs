using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;
using System.ComponentModel;
namespace Stump.Server.WorldServer.Database.Startup
{
	[TableName("startup_actions_items")]
	public sealed class StartupActionItemRecord : IAutoGeneratedRecord
	{
		public uint Id
		{
			get;
			set;
		}
		public int ItemTemplate
		{
			get;
			set;
		}
		public uint Amount
		{
			get;
			set;
		}
		[DefaultValue(true)]
		public bool MaxEffects
		{
			get;
			set;
		}
	}
}
