using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class IgnoredAddRequestMessage : NetworkMessage
	{
        public string name;
        public override uint Id
        {
        	get { return 5673; }
        }
        public IgnoredAddRequestMessage()
        {
        }
        public IgnoredAddRequestMessage(string name)
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
