using Past.Protocol.IO;
using System;

namespace Past.Protocol.Messages
{
    public class DebugInClientMessage : NetworkMessage
	{
        public sbyte level;
        public string message;
        public override uint Id
        {
        	get { return 6028; }
        }
        public DebugInClientMessage()
        {
        }
        public DebugInClientMessage(sbyte level, string message)
        {
            this.level = level;
            this.message = message;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(level);
            writer.WriteUTF(message);
        }
        public override void Deserialize(IDataReader reader)
        {
            level = reader.ReadSByte();
            if (level < 0)
                throw new Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 0");
            message = reader.ReadUTF();
		}
	}
}
