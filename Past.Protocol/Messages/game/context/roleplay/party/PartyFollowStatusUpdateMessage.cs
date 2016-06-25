using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PartyFollowStatusUpdateMessage : NetworkMessage
	{
        public bool success;
        public int followedId;
        public override uint Id
        {
        	get { return 5581; }
        }
        public PartyFollowStatusUpdateMessage()
        {
        }
        public PartyFollowStatusUpdateMessage(bool success, int followedId)
        {
            this.success = success;
            this.followedId = followedId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(success);
            writer.WriteInt(followedId);
        }
        public override void Deserialize(IDataReader reader)
        {
            success = reader.ReadBoolean();
            followedId = reader.ReadInt();
            if (followedId < 0)
                throw new Exception("Forbidden value on followedId = " + followedId + ", it doesn't respect the following condition : followedId < 0");
		}
	}
}
