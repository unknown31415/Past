using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PVPActivationCostMessage : NetworkMessage
	{
        public short cost;
        public override uint Id
        {
        	get { return 1801; }
        }
        public PVPActivationCostMessage()
        {
        }
        public PVPActivationCostMessage(short cost)
        {
            this.cost = cost;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(cost);
        }
        public override void Deserialize(IDataReader reader)
        {
            cost = reader.ReadShort();
            if (cost < 0)
                throw new Exception("Forbidden value on cost = " + cost + ", it doesn't respect the following condition : cost < 0");
		}
	}
}
