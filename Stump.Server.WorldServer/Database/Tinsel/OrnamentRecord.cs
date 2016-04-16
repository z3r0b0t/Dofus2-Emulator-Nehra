using Stump.Core.Reflection;
using Stump.DofusProtocol.Classes;
using Stump.DofusProtocol.Tools.D2o;
using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;
using Stump.Server.WorldServer.Database.I18n;

namespace Stump.Server.WorldServer.Database.Tinsel
{
	[D2OClass("Ornament", "com.ankamagames.dofus.datacenter.appearance", true), TableName("tinsel_ornaments")]
	public class OrnamentRecord : IAutoGeneratedRecord, IAssignedByD2O
	{
		private string m_name;
		[PrimaryKey("Id", false)]
		public int Id
		{
			get;
			set;
		}
		public uint NameId
		{
			get;
			set;
		}
		public string Name
		{
			get
			{
				string arg_23_0;
				if ((arg_23_0 = this.m_name) == null)
				{
					arg_23_0 = (this.m_name = Singleton<TextManager>.Instance.GetText(this.NameId));
				}
				return arg_23_0;
			}
		}
		public bool Visible
		{
			get;
			set;
		}
		public int AssetId
		{
			get;
			set;
		}
		public int IconId
		{
			get;
			set;
		}
		public int Rarity
		{
			get;
			set;
		}
		public int Order
		{
			get;
			set;
		}
		public void AssignFields(object d2oObject)
		{
			Ornament ornament = (Ornament)d2oObject;
			this.Id = ornament.id;
			this.NameId = ornament.nameId;
			this.Visible = ornament.visible;
			this.AssetId = ornament.assetId;
			this.IconId = ornament.iconId;
			this.Rarity = ornament.rarity;
			this.Order = ornament.order;
		}
	}
}
