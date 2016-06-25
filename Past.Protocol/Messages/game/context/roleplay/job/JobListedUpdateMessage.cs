using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class JobListedUpdateMessage : NetworkMessage
	{
        public bool addedOrDeleted;
        public sbyte jobId;
        public override uint Id
        {
        	get { return 6016; }
        }
        public JobListedUpdateMessage()
        {
        }
        public JobListedUpdateMessage(bool addedOrDeleted, sbyte jobId)
        {
            this.addedOrDeleted = addedOrDeleted;
            this.jobId = jobId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(addedOrDeleted);
            writer.WriteSByte(jobId);
        }
        public override void Deserialize(IDataReader reader)
        {
            addedOrDeleted = reader.ReadBoolean();
            jobId = reader.ReadSByte();
            if (jobId < 0)
                throw new Exception("Forbidden value on jobId = " + jobId + ", it doesn't respect the following condition : jobId < 0");
		}
	}
}
