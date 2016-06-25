using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeShopStockMovementUpdatedMessage : NetworkMessage
	{
        public ObjectItemToSell objectInfo;
        public override uint Id
        {
        	get { return 5909; }
        }
        public ExchangeShopStockMovementUpdatedMessage()
        {
        }
        public ExchangeShopStockMovementUpdatedMessage(ObjectItemToSell objectInfo)
        {
            this.objectInfo = objectInfo;
        }
        public override void Serialize(IDataWriter writer)
        {
            objectInfo.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            objectInfo = new ObjectItemToSell();
            objectInfo.Deserialize(reader);
		}
	}
}
