using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class JobCrafterDirectoryEntryMessage : NetworkMessage
	{
        public JobCrafterDirectoryEntryPlayerInfo playerInfo;
        public JobCrafterDirectoryEntryJobInfo[] jobInfoList;
        public EntityLook playerLook;
        public override uint Id
        {
        	get { return 6044; }
        }
        public JobCrafterDirectoryEntryMessage()
        {
        }
        public JobCrafterDirectoryEntryMessage(JobCrafterDirectoryEntryPlayerInfo playerInfo, JobCrafterDirectoryEntryJobInfo[] jobInfoList, EntityLook playerLook)
        {
            this.playerInfo = playerInfo;
            this.jobInfoList = jobInfoList;
            this.playerLook = playerLook;
        }
        public override void Serialize(IDataWriter writer)
        {
            playerInfo.Serialize(writer);
            writer.WriteUShort((ushort)jobInfoList.Length);
            foreach (var entry in jobInfoList)
            {
                 entry.Serialize(writer);
            }
            playerLook.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            playerInfo = new JobCrafterDirectoryEntryPlayerInfo();
            playerInfo.Deserialize(reader);
            var limit = reader.ReadUShort();
            jobInfoList = new JobCrafterDirectoryEntryJobInfo[limit];
            for (int i = 0; i < limit; i++)
            {
                 jobInfoList[i] = new JobCrafterDirectoryEntryJobInfo();
                 jobInfoList[i].Deserialize(reader);
            }
            playerLook = new EntityLook();
            playerLook.Deserialize(reader);
		}
	}
}
