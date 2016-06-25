using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class HouseSoldMessage : NetworkMessage
	{
        public int houseId;
        public int realPrice;
        public string buyerName;
        public override uint Id
        {
        	get { return 5737; }
        }
        public HouseSoldMessage()
        {
        }
        public HouseSoldMessage(int houseId, int realPrice, string buyerName)
        {
            this.houseId = houseId;
            this.realPrice = realPrice;
            this.buyerName = buyerName;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(houseId);
            writer.WriteInt(realPrice);
            writer.WriteUTF(buyerName);
        }
        public override void Deserialize(IDataReader reader)
        {
            houseId = reader.ReadInt();
            if (houseId < 0)
                throw new Exception("Forbidden value on houseId = " + houseId + ", it doesn't respect the following condition : houseId < 0");
            realPrice = reader.ReadInt();
            if (realPrice < 0)
                throw new Exception("Forbidden value on realPrice = " + realPrice + ", it doesn't respect the following condition : realPrice < 0");
            buyerName = reader.ReadUTF();
		}
	}
}
