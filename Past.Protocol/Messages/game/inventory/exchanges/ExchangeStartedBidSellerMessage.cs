using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeStartedBidSellerMessage : NetworkMessage
	{
        public SellerBuyerDescriptor sellerDescriptor;
        public ObjectItemToSellInBid[] objectsInfos;
        public override uint Id
        {
        	get { return 5905; }
        }
        public ExchangeStartedBidSellerMessage()
        {
        }
        public ExchangeStartedBidSellerMessage(SellerBuyerDescriptor sellerDescriptor, ObjectItemToSellInBid[] objectsInfos)
        {
            this.sellerDescriptor = sellerDescriptor;
            this.objectsInfos = objectsInfos;
        }
        public override void Serialize(IDataWriter writer)
        {
            sellerDescriptor.Serialize(writer);
            writer.WriteUShort((ushort)objectsInfos.Length);
            foreach (var entry in objectsInfos)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            sellerDescriptor = new SellerBuyerDescriptor();
            sellerDescriptor.Deserialize(reader);
            var limit = reader.ReadUShort();
            objectsInfos = new ObjectItemToSellInBid[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectsInfos[i] = new ObjectItemToSellInBid();
                 objectsInfos[i].Deserialize(reader);
            }
		}
	}
}
