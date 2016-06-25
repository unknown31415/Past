using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class JobCrafterDirectoryAddMessage : NetworkMessage
	{
        public JobCrafterDirectoryListEntry listEntry;
        public override uint Id
        {
        	get { return 5651; }
        }
        public JobCrafterDirectoryAddMessage()
        {
        }
        public JobCrafterDirectoryAddMessage(JobCrafterDirectoryListEntry listEntry)
        {
            this.listEntry = listEntry;
        }
        public override void Serialize(IDataWriter writer)
        {
            listEntry.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            listEntry = new JobCrafterDirectoryListEntry();
            listEntry.Deserialize(reader);
		}
	}
}
