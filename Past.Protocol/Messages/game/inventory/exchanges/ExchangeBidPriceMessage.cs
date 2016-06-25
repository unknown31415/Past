using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeBidPriceMessage : NetworkMessage
	{
        public int genericId;
        public int averagePrice;
        public override uint Id
        {
        	get { return 5755; }
        }
        public ExchangeBidPriceMessage()
        {
        }
        public ExchangeBidPriceMessage(int genericId, int averagePrice)
        {
            this.genericId = genericId;
            this.averagePrice = averagePrice;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(genericId);
            writer.WriteInt(averagePrice);
        }
        public override void Deserialize(IDataReader reader)
        {
            genericId = reader.ReadInt();
            if (genericId < 0)
                throw new Exception("Forbidden value on genericId = " + genericId + ", it doesn't respect the following condition : genericId < 0");
            averagePrice = reader.ReadInt();
            if (averagePrice < 0)
                throw new Exception("Forbidden value on averagePrice = " + averagePrice + ", it doesn't respect the following condition : averagePrice < 0");
		}
	}
}
