using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class JobCrafterDirectoryListMessage : NetworkMessage
	{
        public JobCrafterDirectoryListEntry[] listEntries;
        public override uint Id
        {
        	get { return 6046; }
        }
        public JobCrafterDirectoryListMessage()
        {
        }
        public JobCrafterDirectoryListMessage(JobCrafterDirectoryListEntry[] listEntries)
        {
            this.listEntries = listEntries;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)listEntries.Length);
            foreach (var entry in listEntries)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            listEntries = new JobCrafterDirectoryListEntry[limit];
            for (int i = 0; i < limit; i++)
            {
                 listEntries[i] = new JobCrafterDirectoryListEntry();
                 listEntries[i].Deserialize(reader);
            }
		}
	}
}
