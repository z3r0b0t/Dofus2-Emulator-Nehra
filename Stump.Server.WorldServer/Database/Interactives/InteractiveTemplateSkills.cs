using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;

namespace Stump.Server.WorldServer.Database.Interactives
{
	[TableName("interactives_templates_skills")]
	public class InteractiveTemplateSkills : IAutoGeneratedRecord
	{
		[PrimaryKey("Id", true)]
		public int Id
		{
			get;
			set;
		}
		[Column("InteractiveTemplateId"), Index]
		public int InteractiveTemplateId
		{
			get;
			set;
		}
		[Column("SkillId")]
		public int SkillId
		{
			get;
			set;
		}
	}
}
