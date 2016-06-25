using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class FriendDeleteRequestMessage : NetworkMessage
	{
        public string name;
        public override uint Id
        {
        	get { return 5603; }
        }
        public FriendDeleteRequestMessage()
        {
        }
        public FriendDeleteRequestMessage(string name)
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
