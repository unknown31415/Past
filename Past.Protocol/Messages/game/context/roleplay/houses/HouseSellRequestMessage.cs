using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class HouseSellRequestMessage : NetworkMessage
	{
        public int amount;
        public override uint Id
        {
        	get { return 5697; }
        }
        public HouseSellRequestMessage()
        {
        }
        public HouseSellRequestMessage(int amount)
        {
            this.amount = amount;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(amount);
        }
        public override void Deserialize(IDataReader reader)
        {
            amount = reader.ReadInt();
            if (amount < 0)
                throw new Exception("Forbidden value on amount = " + amount + ", it doesn't respect the following condition : amount < 0");
		}
	}
}
