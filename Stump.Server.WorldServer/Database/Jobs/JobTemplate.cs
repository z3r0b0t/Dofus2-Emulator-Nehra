using Stump.Core.IO;
using Stump.Core.Reflection;
using Stump.DofusProtocol.Classes;
using Stump.DofusProtocol.Tools.D2o;
using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;
using Stump.Server.WorldServer.Database.I18n;

namespace Stump.Server.WorldServer.Database.Jobs
{
    [D2OClass("Job", "com.ankamagames.dofus.datacenter.jobs", true), TableName("jobs_templates")]
    public class JobTemplate : IAutoGeneratedRecord, ISaveIntercepter, IAssignedByD2O
    {
        private string m_name;
        private int[] m_toolIds;
        private string m_toolIdsCSV;

        [PrimaryKey("Id", false)]
        public int Id { get; set; }

        public uint NameId { get; set; }

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

        public int SpecializationOfId { get; set; }
        public int IconId { get; set; }

        public string ToolIdsCSV
        {
            get { return this.m_toolIdsCSV; }
            set
            {
                this.m_toolIdsCSV = value;
                this.m_toolIds = value.FromCSV<int>(",");
            }
        }

        [Ignore]
        public int[] ToolIds
        {
            get { return this.m_toolIds; }
            set
            {
                this.m_toolIds = value;
                this.m_toolIdsCSV = value.ToCSV(",");
            }
        }

        public void AssignFields(object d2oObject)
        {
            Job job = (Job) d2oObject;
            this.Id = job.id;
            this.NameId = job.nameId;
            this.IconId = job.iconId;
            this.m_toolIds = new int[0];
        }

        public void BeforeSave(bool insert)
        {
            this.m_toolIdsCSV = this.m_toolIds.ToCSV(",");
        }
    }
}
