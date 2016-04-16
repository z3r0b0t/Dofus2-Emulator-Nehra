using Stump.DofusProtocol.Enums;
using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;
using Stump.Server.WorldServer.Database.Characters;

namespace Stump.Server.WorldServer.Database.Guilds
{
	[TableName("guild_members")]
	public class GuildMemberRecord : IAutoGeneratedRecord
	{
		[PrimaryKey("CharacterId", false)]
		public int CharacterId
		{
			get;
			set;
		}
		[Ignore]
		public CharacterRecord Character
		{
			get;
			set;
		}
		public int AccountId
		{
			get;
			set;
		}
		public int GuildId
		{
			get;
			set;
		}
		public short RankId
		{
			get;
			set;
		}
		public GuildRightsBitEnum Rights
		{
			get;
			set;
		}
		public long GivenExperience
		{
			get;
			set;
		}
		public byte GivenPercent
		{
			get;
			set;
		}
		public string Name
		{
			get
			{
				return this.Character.Name;
			}
		}
		public long Experience
		{
			get
			{
				return this.Character.Experience;
			}
		}
		public PlayableBreedEnum Breed
		{
			get
			{
				return this.Character.Breed;
			}
		}
		public SexTypeEnum Sex
		{
			get
			{
				return this.Character.Sex;
			}
		}
		public AlignmentSideEnum AlignementSide
		{
			get
			{
				return this.Character.AlignmentSide;
			}
		}
		public System.DateTime? LastConnection
		{
			get
			{
				return this.Character.LastUsage;
			}
		}
	}
}
