using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PaddockSellBuyDialogMessage : NetworkMessage
	{
        public bool bsell;
        public int ownerId;
        public int price;
        public override uint Id
        {
        	get { return 6018; }
        }
        public PaddockSellBuyDialogMessage()
        {
        }
        public PaddockSellBuyDialogMessage(bool bsell, int ownerId, int price)
        {
            this.bsell = bsell;
            this.ownerId = ownerId;
            this.price = price;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(bsell);
            writer.WriteInt(ownerId);
            writer.WriteInt(price);
        }
        public override void Deserialize(IDataReader reader)
        {
            bsell = reader.ReadBoolean();
            ownerId = reader.ReadInt();
            if (ownerId < 0)
                throw new Exception("Forbidden value on ownerId = " + ownerId + ", it doesn't respect the following condition : ownerId < 0");
            price = reader.ReadInt();
            if (price < 0)
                throw new Exception("Forbidden value on price = " + price + ", it doesn't respect the following condition : price < 0");
		}
	}
}
