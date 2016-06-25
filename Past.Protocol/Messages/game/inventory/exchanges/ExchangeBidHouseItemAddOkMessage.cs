using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeBidHouseItemAddOkMessage : NetworkMessage
	{
        public ObjectItemToSellInBid itemInfo;
        public override uint Id
        {
        	get { return 5945; }
        }
        public ExchangeBidHouseItemAddOkMessage()
        {
        }
        public ExchangeBidHouseItemAddOkMessage(ObjectItemToSellInBid itemInfo)
        {
            this.itemInfo = itemInfo;
        }
        public override void Serialize(IDataWriter writer)
        {
            itemInfo.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            itemInfo = new ObjectItemToSellInBid();
            itemInfo.Deserialize(reader);
		}
	}
}
