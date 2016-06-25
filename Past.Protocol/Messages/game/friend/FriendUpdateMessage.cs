using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class FriendUpdateMessage : NetworkMessage
	{
        public FriendInformations friendUpdated;
        public override uint Id
        {
        	get { return 5924; }
        }
        public FriendUpdateMessage()
        {
        }
        public FriendUpdateMessage(FriendInformations friendUpdated)
        {
            this.friendUpdated = friendUpdated;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(friendUpdated.TypeId);
            friendUpdated.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            friendUpdated = (FriendInformations)ProtocolTypeManager.GetInstance(reader.ReadUShort());
            friendUpdated.Deserialize(reader);
		}
	}
}
