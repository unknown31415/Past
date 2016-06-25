using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class FriendAddedMessage : NetworkMessage
	{
        public FriendInformations friendAdded;
        public override uint Id
        {
        	get { return 5599; }
        }
        public FriendAddedMessage()
        {
        }
        public FriendAddedMessage(FriendInformations friendAdded)
        {
            this.friendAdded = friendAdded;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(friendAdded.TypeId);
            friendAdded.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            friendAdded = (FriendInformations)ProtocolTypeManager.GetInstance(reader.ReadUShort());
            friendAdded.Deserialize(reader);
		}
	}
}
