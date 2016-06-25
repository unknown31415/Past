using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class BasicTimeMessage : NetworkMessage
	{
        public int timestamp;
        public short timezoneOffset;
        public override uint Id
        {
        	get { return 175; }
        }
        public BasicTimeMessage()
        {
        }
        public BasicTimeMessage(int timestamp, short timezoneOffset)
        {
            this.timestamp = timestamp;
            this.timezoneOffset = timezoneOffset;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(timestamp);
            writer.WriteShort(timezoneOffset);
        }
        public override void Deserialize(IDataReader reader)
        {
            timestamp = reader.ReadInt();
            if (timestamp < 0)
                throw new Exception("Forbidden value on timestamp = " + timestamp + ", it doesn't respect the following condition : timestamp < 0");
            timezoneOffset = reader.ReadShort();
		}
	}
}
