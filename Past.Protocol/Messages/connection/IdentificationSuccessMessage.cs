using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class IdentificationSuccessMessage : NetworkMessage
	{
        public bool hasRights;
        public bool wasAlreadyConnected;
        public string nickname;
        public sbyte communityId;
        public string secretQuestion;
        public double remainingSubscriptionTime;
        public override uint Id
        {
        	get { return 22; }
        }
        public IdentificationSuccessMessage()
        {
        }
        public IdentificationSuccessMessage(bool hasRights, bool wasAlreadyConnected, string nickname, sbyte communityId, string secretQuestion, double remainingSubscriptionTime)
        {
            this.hasRights = hasRights;
            this.wasAlreadyConnected = wasAlreadyConnected;
            this.nickname = nickname;
            this.communityId = communityId;
            this.secretQuestion = secretQuestion;
            this.remainingSubscriptionTime = remainingSubscriptionTime;
        }
        public override void Serialize(IDataWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, hasRights);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, wasAlreadyConnected);
            writer.WriteByte(flag1);
            writer.WriteUTF(nickname);
            writer.WriteSByte(communityId);
            writer.WriteUTF(secretQuestion);
            writer.WriteDouble(remainingSubscriptionTime);
        }
        public override void Deserialize(IDataReader reader)
        {
            byte flag1 = reader.ReadByte();
            hasRights = BooleanByteWrapper.GetFlag(flag1, 0);
            wasAlreadyConnected = BooleanByteWrapper.GetFlag(flag1, 1);
            nickname = reader.ReadUTF();
            communityId = reader.ReadSByte();
            if (communityId < 0)
                throw new Exception("Forbidden value on communityId = " + communityId + ", it doesn't respect the following condition : communityId < 0");
            secretQuestion = reader.ReadUTF();
            remainingSubscriptionTime = reader.ReadDouble();
            if (remainingSubscriptionTime < 0)
                throw new Exception("Forbidden value on remainingSubscriptionTime = " + remainingSubscriptionTime + ", it doesn't respect the following condition : remainingSubscriptionTime < 0");
		}
	}
}
