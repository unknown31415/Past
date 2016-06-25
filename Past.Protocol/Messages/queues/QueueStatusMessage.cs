using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class QueueStatusMessage : NetworkMessage
	{
        public ushort position;
        public ushort total;
        public override uint Id
        {
        	get { return 6100; }
        }
        public QueueStatusMessage()
        {
        }
        public QueueStatusMessage(ushort position, ushort total)
        {
            this.position = position;
            this.total = total;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort(position);
            writer.WriteUShort(total);
        }
        public override void Deserialize(IDataReader reader)
        {
            position = reader.ReadUShort();
            if (position < 0 || position > 65535)
                throw new Exception("Forbidden value on position = " + position + ", it doesn't respect the following condition : position < 0 || position > 65535");
            total = reader.ReadUShort();
            if (total < 0 || total > 65535)
                throw new Exception("Forbidden value on total = " + total + ", it doesn't respect the following condition : total < 0 || total > 65535");
		}
	}
}
