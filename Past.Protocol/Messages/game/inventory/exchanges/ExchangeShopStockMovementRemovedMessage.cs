using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeShopStockMovementRemovedMessage : NetworkMessage
	{
        public int objectId;
        public override uint Id
        {
        	get { return 5907; }
        }
        public ExchangeShopStockMovementRemovedMessage()
        {
        }
        public ExchangeShopStockMovementRemovedMessage(int objectId)
        {
            this.objectId = objectId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(objectId);
        }
        public override void Deserialize(IDataReader reader)
        {
            objectId = reader.ReadInt();
            if (objectId < 0)
                throw new Exception("Forbidden value on objectId = " + objectId + ", it doesn't respect the following condition : objectId < 0");
		}
	}
}
