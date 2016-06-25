using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ChallengeTargetsListRequestMessage : NetworkMessage
	{
        public sbyte challengeId;
        public override uint Id
        {
        	get { return 5614; }
        }
        public ChallengeTargetsListRequestMessage()
        {
        }
        public ChallengeTargetsListRequestMessage(sbyte challengeId)
        {
            this.challengeId = challengeId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(challengeId);
        }
        public override void Deserialize(IDataReader reader)
        {
            challengeId = reader.ReadSByte();
            if (challengeId < 0)
                throw new Exception("Forbidden value on challengeId = " + challengeId + ", it doesn't respect the following condition : challengeId < 0");
		}
	}
}
