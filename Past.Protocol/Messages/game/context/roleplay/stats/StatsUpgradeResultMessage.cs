using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class StatsUpgradeResultMessage : NetworkMessage
	{
        public short nbCharacBoost;
        public override uint Id
        {
        	get { return 5609; }
        }
        public StatsUpgradeResultMessage()
        {
        }
        public StatsUpgradeResultMessage(short nbCharacBoost)
        {
            this.nbCharacBoost = nbCharacBoost;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(nbCharacBoost);
        }
        public override void Deserialize(IDataReader reader)
        {
            nbCharacBoost = reader.ReadShort();
            if (nbCharacBoost < 0)
                throw new Exception("Forbidden value on nbCharacBoost = " + nbCharacBoost + ", it doesn't respect the following condition : nbCharacBoost < 0");
		}
	}
}
