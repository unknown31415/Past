using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeWeightMessage : NetworkMessage
	{
        public int currentWeight;
        public int maxWeight;
        public override uint Id
        {
        	get { return 5793; }
        }
        public ExchangeWeightMessage()
        {
        }
        public ExchangeWeightMessage(int currentWeight, int maxWeight)
        {
            this.currentWeight = currentWeight;
            this.maxWeight = maxWeight;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(currentWeight);
            writer.WriteInt(maxWeight);
        }
        public override void Deserialize(IDataReader reader)
        {
            currentWeight = reader.ReadInt();
            if (currentWeight < 0)
                throw new Exception("Forbidden value on currentWeight = " + currentWeight + ", it doesn't respect the following condition : currentWeight < 0");
            maxWeight = reader.ReadInt();
            if (maxWeight < 0)
                throw new Exception("Forbidden value on maxWeight = " + maxWeight + ", it doesn't respect the following condition : maxWeight < 0");
		}
	}
}
