using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeSellMessage : NetworkMessage
	{
        public int objectToSellId;
        public int quantity;
        public override uint Id
        {
        	get { return 5778; }
        }
        public ExchangeSellMessage()
        {
        }
        public ExchangeSellMessage(int objectToSellId, int quantity)
        {
            this.objectToSellId = objectToSellId;
            this.quantity = quantity;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(objectToSellId);
            writer.WriteInt(quantity);
        }
        public override void Deserialize(IDataReader reader)
        {
            objectToSellId = reader.ReadInt();
            if (objectToSellId < 0)
                throw new Exception("Forbidden value on objectToSellId = " + objectToSellId + ", it doesn't respect the following condition : objectToSellId < 0");
            quantity = reader.ReadInt();
            if (quantity < 0)
                throw new Exception("Forbidden value on quantity = " + quantity + ", it doesn't respect the following condition : quantity < 0");
		}
	}
}
