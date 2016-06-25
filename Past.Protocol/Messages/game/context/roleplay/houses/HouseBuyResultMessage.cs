using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class HouseBuyResultMessage : NetworkMessage
	{
        public int houseId;
        public bool bought;
        public int realPrice;
        public override uint Id
        {
        	get { return 5735; }
        }
        public HouseBuyResultMessage()
        {
        }
        public HouseBuyResultMessage(int houseId, bool bought, int realPrice)
        {
            this.houseId = houseId;
            this.bought = bought;
            this.realPrice = realPrice;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(houseId);
            writer.WriteBoolean(bought);
            writer.WriteInt(realPrice);
        }
        public override void Deserialize(IDataReader reader)
        {
            houseId = reader.ReadInt();
            if (houseId < 0)
                throw new Exception("Forbidden value on houseId = " + houseId + ", it doesn't respect the following condition : houseId < 0");
            bought = reader.ReadBoolean();
            realPrice = reader.ReadInt();
            if (realPrice < 0)
                throw new Exception("Forbidden value on realPrice = " + realPrice + ", it doesn't respect the following condition : realPrice < 0");
		}
	}
}
