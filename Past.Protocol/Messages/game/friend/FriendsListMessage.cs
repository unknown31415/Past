using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class FriendsListMessage : NetworkMessage
	{
        public FriendInformations[] friendsList;
        public override uint Id
        {
        	get { return 4002; }
        }
        public FriendsListMessage()
        {
        }
        public FriendsListMessage(FriendInformations[] friendsList)
        {
            this.friendsList = friendsList;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)friendsList.Length);
            foreach (var entry in friendsList)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            friendsList = new FriendInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 friendsList[i] = (FriendInformations)ProtocolTypeManager.GetInstance(reader.ReadUShort());
                 friendsList[i].Deserialize(reader);
            }
		}
	}
}
