using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PaddockSellRequestMessage : NetworkMessage
	{
        public int price;
        public override uint Id
        {
        	get { return 5953; }
        }
        public PaddockSellRequestMessage()
        {
        }
        public PaddockSellRequestMessage(int price)
        {
            this.price = price;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(price);
        }
        public override void Deserialize(IDataReader reader)
        {
            price = reader.ReadInt();
            if (price < 0)
                throw new Exception("Forbidden value on price = " + price + ", it doesn't respect the following condition : price < 0");
		}
	}
}
