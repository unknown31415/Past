using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class OnConnectionEventMessage : NetworkMessage
	{
        public sbyte eventType;
        public override uint Id
        {
        	get { return 5726; }
        }
        public OnConnectionEventMessage()
        {
        }
        public OnConnectionEventMessage(sbyte eventType)
        {
            this.eventType = eventType;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(eventType);
        }
        public override void Deserialize(IDataReader reader)
        {
            eventType = reader.ReadSByte();
            if (eventType < 0)
                throw new Exception("Forbidden value on eventType = " + eventType + ", it doesn't respect the following condition : eventType < 0");
		}
	}
}
