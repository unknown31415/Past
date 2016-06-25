using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildGetInformationsMessage : NetworkMessage
	{
        public sbyte infoType;
        public override uint Id
        {
        	get { return 5550; }
        }
        public GuildGetInformationsMessage()
        {
        }
        public GuildGetInformationsMessage(sbyte infoType)
        {
            this.infoType = infoType;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(infoType);
        }
        public override void Deserialize(IDataReader reader)
        {
            infoType = reader.ReadSByte();
            if (infoType < 0)
                throw new Exception("Forbidden value on infoType = " + infoType + ", it doesn't respect the following condition : infoType < 0");
		}
	}
}
