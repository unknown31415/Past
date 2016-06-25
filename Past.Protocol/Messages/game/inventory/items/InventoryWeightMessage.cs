using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class InventoryWeightMessage : NetworkMessage
	{
        public int weight;
        public int weightMax;
        public override uint Id
        {
        	get { return 3009; }
        }
        public InventoryWeightMessage()
        {
        }
        public InventoryWeightMessage(int weight, int weightMax)
        {
            this.weight = weight;
            this.weightMax = weightMax;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(weight);
            writer.WriteInt(weightMax);
        }
        public override void Deserialize(IDataReader reader)
        {
            weight = reader.ReadInt();
            if (weight < 0)
                throw new Exception("Forbidden value on weight = " + weight + ", it doesn't respect the following condition : weight < 0");
            weightMax = reader.ReadInt();
            if (weightMax < 0)
                throw new Exception("Forbidden value on weightMax = " + weightMax + ", it doesn't respect the following condition : weightMax < 0");
		}
	}
}
