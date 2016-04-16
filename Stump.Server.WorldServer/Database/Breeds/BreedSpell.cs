using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;

namespace Stump.Server.WorldServer.Database.Breeds
{
	[TableName("breeds_spells")]
	public class BreedSpell : IAutoGeneratedRecord
	{
		public int Id
		{
			get;
			set;
		}
		public int Spell
		{
			get;
			set;
		}
		public int ObtainLevel
		{
			get;
			set;
		}
		public int BreedId
		{
			get;
			set;
		}
	}
}
