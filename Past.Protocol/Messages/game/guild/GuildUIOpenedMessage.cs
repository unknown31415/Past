using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildUIOpenedMessage : NetworkMessage
	{
        public sbyte type;
        public override uint Id
        {
        	get { return 5561; }
        }
        public GuildUIOpenedMessage()
        {
        }
        public GuildUIOpenedMessage(sbyte type)
        {
            this.type = type;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(type);
        }
        public override void Deserialize(IDataReader reader)
        {
            type = reader.ReadSByte();
            if (type < 0)
                throw new Exception("Forbidden value on type = " + type + ", it doesn't respect the following condition : type < 0");
		}
	}
}
