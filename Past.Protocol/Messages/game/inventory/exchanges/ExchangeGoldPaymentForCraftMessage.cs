using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeGoldPaymentForCraftMessage : NetworkMessage
	{
        public bool onlySuccess;
        public int goldSum;
        public override uint Id
        {
        	get { return 5833; }
        }
        public ExchangeGoldPaymentForCraftMessage()
        {
        }
        public ExchangeGoldPaymentForCraftMessage(bool onlySuccess, int goldSum)
        {
            this.onlySuccess = onlySuccess;
            this.goldSum = goldSum;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(onlySuccess);
            writer.WriteInt(goldSum);
        }
        public override void Deserialize(IDataReader reader)
        {
            onlySuccess = reader.ReadBoolean();
            goldSum = reader.ReadInt();
            if (goldSum < 0)
                throw new Exception("Forbidden value on goldSum = " + goldSum + ", it doesn't respect the following condition : goldSum < 0");
		}
	}
}
