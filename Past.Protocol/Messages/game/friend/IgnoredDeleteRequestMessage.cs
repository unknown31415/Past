using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class IgnoredDeleteRequestMessage : NetworkMessage
	{
        public string name;
        public override uint Id
        {
        	get { return 5680; }
        }
        public IgnoredDeleteRequestMessage()
        {
        }
        public IgnoredDeleteRequestMessage(string name)
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
