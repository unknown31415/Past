using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class EmoteAddMessage : NetworkMessage
	{
        public sbyte emoteId;
        public override uint Id
        {
        	get { return 5644; }
        }
        public EmoteAddMessage()
        {
        }
        public EmoteAddMessage(sbyte emoteId)
        {
            this.emoteId = emoteId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(emoteId);
        }
        public override void Deserialize(IDataReader reader)
        {
            emoteId = reader.ReadSByte();
            if (emoteId < 0)
                throw new Exception("Forbidden value on emoteId = " + emoteId + ", it doesn't respect the following condition : emoteId < 0");
		}
	}
}
