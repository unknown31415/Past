using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ChallengeResultMessage : NetworkMessage
	{
        public sbyte challengeId;
        public bool success;
        public override uint Id
        {
        	get { return 6019; }
        }
        public ChallengeResultMessage()
        {
        }
        public ChallengeResultMessage(sbyte challengeId, bool success)
        {
            this.challengeId = challengeId;
            this.success = success;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(challengeId);
            writer.WriteBoolean(success);
        }
        public override void Deserialize(IDataReader reader)
        {
            challengeId = reader.ReadSByte();
            if (challengeId < 0)
                throw new Exception("Forbidden value on challengeId = " + challengeId + ", it doesn't respect the following condition : challengeId < 0");
            success = reader.ReadBoolean();
		}
	}
}
