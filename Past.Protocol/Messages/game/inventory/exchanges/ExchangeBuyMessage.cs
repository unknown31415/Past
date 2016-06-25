using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeBuyMessage : NetworkMessage
	{
        public int objectToBuyId;
        public int quantity;
        public override uint Id
        {
        	get { return 5774; }
        }
        public ExchangeBuyMessage()
        {
        }
        public ExchangeBuyMessage(int objectToBuyId, int quantity)
        {
            this.objectToBuyId = objectToBuyId;
            this.quantity = quantity;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(objectToBuyId);
            writer.WriteInt(quantity);
        }
        public override void Deserialize(IDataReader reader)
        {
            objectToBuyId = reader.ReadInt();
            if (objectToBuyId < 0)
                throw new Exception("Forbidden value on objectToBuyId = " + objectToBuyId + ", it doesn't respect the following condition : objectToBuyId < 0");
            quantity = reader.ReadInt();
            if (quantity < 0)
                throw new Exception("Forbidden value on quantity = " + quantity + ", it doesn't respect the following condition : quantity < 0");
		}
	}
}
