using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ClientKeyMessage : NetworkMessage
	{
        public string key;
        public override uint Id
        {
        	get { return 5607; }
        }
        public ClientKeyMessage()
        {
        }
        public ClientKeyMessage(string key)
        {
            this.key = key;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(key);
        }
        public override void Deserialize(IDataReader reader)
        {
            key = reader.ReadUTF();
		}
	}
}
