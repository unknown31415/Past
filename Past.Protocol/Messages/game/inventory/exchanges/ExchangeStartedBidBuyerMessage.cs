using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeStartedBidBuyerMessage : NetworkMessage
	{
        public SellerBuyerDescriptor buyerDescriptor;
        public override uint Id
        {
        	get { return 5904; }
        }
        public ExchangeStartedBidBuyerMessage()
        {
        }
        public ExchangeStartedBidBuyerMessage(SellerBuyerDescriptor buyerDescriptor)
        {
            this.buyerDescriptor = buyerDescriptor;
        }
        public override void Serialize(IDataWriter writer)
        {
            buyerDescriptor.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            buyerDescriptor = new SellerBuyerDescriptor();
            buyerDescriptor.Deserialize(reader);
		}
	}
}
