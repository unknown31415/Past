using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ConsoleMessage : NetworkMessage
	{
        public sbyte type;
        public string content;
        public override uint Id
        {
        	get { return 75; }
        }
        public ConsoleMessage()
        {
        }
        public ConsoleMessage(sbyte type, string content)
        {
            this.type = type;
            this.content = content;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(type);
            writer.WriteUTF(content);
        }
        public override void Deserialize(IDataReader reader)
        {
            type = reader.ReadSByte();
            if (type < 0)
                throw new Exception("Forbidden value on type = " + type + ", it doesn't respect the following condition : type < 0");
            content = reader.ReadUTF();
		}
	}
}
