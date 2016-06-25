using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class JobCrafterDirectoryRemoveMessage : NetworkMessage
	{
        public sbyte jobId;
        public int playerId;
        public override uint Id
        {
        	get { return 5653; }
        }
        public JobCrafterDirectoryRemoveMessage()
        {
        }
        public JobCrafterDirectoryRemoveMessage(sbyte jobId, int playerId)
        {
            this.jobId = jobId;
            this.playerId = playerId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(jobId);
            writer.WriteInt(playerId);
        }
        public override void Deserialize(IDataReader reader)
        {
            jobId = reader.ReadSByte();
            if (jobId < 0)
                throw new Exception("Forbidden value on jobId = " + jobId + ", it doesn't respect the following condition : jobId < 0");
            playerId = reader.ReadInt();
            if (playerId < 0)
                throw new Exception("Forbidden value on playerId = " + playerId + ", it doesn't respect the following condition : playerId < 0");
		}
	}
}
