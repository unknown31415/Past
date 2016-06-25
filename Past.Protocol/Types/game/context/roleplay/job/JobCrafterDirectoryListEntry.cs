using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class JobCrafterDirectoryListEntry
    {
        public JobCrafterDirectoryEntryPlayerInfo playerInfo;
        public JobCrafterDirectoryEntryJobInfo jobInfo;
        public const short Id = 196;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public JobCrafterDirectoryListEntry()
        {
        }
        public JobCrafterDirectoryListEntry(JobCrafterDirectoryEntryPlayerInfo playerInfo, JobCrafterDirectoryEntryJobInfo jobInfo)
        {
            this.playerInfo = playerInfo;
            this.jobInfo = jobInfo;
        }
        public virtual void Serialize(IDataWriter writer)
        {
            playerInfo.Serialize(writer);
            jobInfo.Serialize(writer);
        }
        public virtual void Deserialize(IDataReader reader)
        {
            playerInfo = new JobCrafterDirectoryEntryPlayerInfo();
            playerInfo.Deserialize(reader);
            jobInfo = new JobCrafterDirectoryEntryJobInfo();
            jobInfo.Deserialize(reader);
        }
    }
}

