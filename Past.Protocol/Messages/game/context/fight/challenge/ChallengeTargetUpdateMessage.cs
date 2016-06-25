using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ChallengeTargetUpdateMessage : NetworkMessage
	{
        public sbyte challengeId;
        public int targetId;
        public override uint Id
        {
        	get { return 6123; }
        }
        public ChallengeTargetUpdateMessage()
        {
        }
        public ChallengeTargetUpdateMessage(sbyte challengeId, int targetId)
        {
            this.challengeId = challengeId;
            this.targetId = targetId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(challengeId);
            writer.WriteInt(targetId);
        }
        public override void Deserialize(IDataReader reader)
        {
            challengeId = reader.ReadSByte();
            if (challengeId < 0)
                throw new Exception("Forbidden value on challengeId = " + challengeId + ", it doesn't respect the following condition : challengeId < 0");
            targetId = reader.ReadInt();
		}
	}
}
