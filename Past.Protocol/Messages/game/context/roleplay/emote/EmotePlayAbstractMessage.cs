using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class EmotePlayAbstractMessage : NetworkMessage
	{
        public sbyte emoteId;
        public byte duration;
        public override uint Id
        {
        	get { return 5690; }
        }
        public EmotePlayAbstractMessage()
        {
        }
        public EmotePlayAbstractMessage(sbyte emoteId, byte duration)
        {
            this.emoteId = emoteId;
            this.duration = duration;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(emoteId);
            writer.WriteByte(duration);
        }
        public override void Deserialize(IDataReader reader)
        {
            emoteId = reader.ReadSByte();
            if (emoteId < 0)
                throw new Exception("Forbidden value on emoteId = " + emoteId + ", it doesn't respect the following condition : emoteId < 0");
            duration = reader.ReadByte();
            if (duration < 0 || duration > 255)
                throw new Exception("Forbidden value on duration = " + duration + ", it doesn't respect the following condition : duration < 0 || duration > 255");
		}
	}
}
