using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class JobCrafterDirectoryListRequestMessage : NetworkMessage
	{
        public sbyte jobId;
        public override uint Id
        {
        	get { return 6047; }
        }
        public JobCrafterDirectoryListRequestMessage()
        {
        }
        public JobCrafterDirectoryListRequestMessage(sbyte jobId)
        {
            this.jobId = jobId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(jobId);
        }
        public override void Deserialize(IDataReader reader)
        {
            jobId = reader.ReadSByte();
            if (jobId < 0)
                throw new Exception("Forbidden value on jobId = " + jobId + ", it doesn't respect the following condition : jobId < 0");
		}
	}
}
