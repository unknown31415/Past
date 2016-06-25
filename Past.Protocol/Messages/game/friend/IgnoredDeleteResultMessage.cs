using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class IgnoredDeleteResultMessage : NetworkMessage
	{
        public bool success;
        public string name;
        public override uint Id
        {
        	get { return 5677; }
        }
        public IgnoredDeleteResultMessage()
        {
        }
        public IgnoredDeleteResultMessage(bool success, string name)
        {
            this.success = success;
            this.name = name;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(success);
            writer.WriteUTF(name);
        }
        public override void Deserialize(IDataReader reader)
        {
            success = reader.ReadBoolean();
            name = reader.ReadUTF();
		}
	}
}
