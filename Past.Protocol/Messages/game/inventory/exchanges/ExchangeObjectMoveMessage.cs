using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeObjectMoveMessage : NetworkMessage
	{
        public int objectUID;
        public short quantity;
        public override uint Id
        {
        	get { return 5518; }
        }
        public ExchangeObjectMoveMessage()
        {
        }
        public ExchangeObjectMoveMessage(int objectUID, short quantity)
        {
            this.objectUID = objectUID;
            this.quantity = quantity;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(objectUID);
            writer.WriteShort(quantity);
        }
        public override void Deserialize(IDataReader reader)
        {
            objectUID = reader.ReadInt();
            if (objectUID < 0)
                throw new Exception("Forbidden value on objectUID = " + objectUID + ", it doesn't respect the following condition : objectUID < 0");
            quantity = reader.ReadShort();
		}
	}
}
