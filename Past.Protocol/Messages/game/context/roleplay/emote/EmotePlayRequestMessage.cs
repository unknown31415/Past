using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class EmotePlayRequestMessage : NetworkMessage
	{
        public sbyte emoteId;
        public override uint Id
        {
        	get { return 5685; }
        }
        public EmotePlayRequestMessage()
        {
        }
        public EmotePlayRequestMessage(sbyte emoteId)
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
