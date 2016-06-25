using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class FriendJoinRequestMessage : NetworkMessage
	{
        public string name;
        public override uint Id
        {
        	get { return 5605; }
        }
        public FriendJoinRequestMessage()
        {
        }
        public FriendJoinRequestMessage(string name)
        {
            this.name = name;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(name);
        }
        public override void Deserialize(IDataReader reader)
        {
            name = reader.ReadUTF();
		}
	}
}
