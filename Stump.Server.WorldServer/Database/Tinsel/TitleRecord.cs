using Stump.Core.Reflection;
using Stump.DofusProtocol.Classes;
using Stump.DofusProtocol.Tools.D2o;
using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;
using Stump.Server.WorldServer.Database.I18n;

namespace Stump.Server.WorldServer.Database.Tinsel
{
	[D2OClass("Title", "com.ankamagames.dofus.datacenter.appearance", true), TableName("tinsel_titles")]
	public class TitleRecord : IAutoGeneratedRecord, IAssignedByD2O
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
		public int CategoryId
		{
			get;
			set;
		}
		public void AssignFields(object d2oObject)
		{
			Title title = (Title)d2oObject;
			this.Id = title.id;
			this.NameId = title.nameMaleId;
			this.Visible = title.visible;
			this.CategoryId = title.categoryId;
		}
	}
}
