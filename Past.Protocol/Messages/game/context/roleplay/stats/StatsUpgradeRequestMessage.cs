using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class StatsUpgradeRequestMessage : NetworkMessage
	{
        public sbyte statId;
        public short boostPoint;
        public override uint Id
        {
        	get { return 5610; }
        }
        public StatsUpgradeRequestMessage()
        {
        }
        public StatsUpgradeRequestMessage(sbyte statId, short boostPoint)
        {
            this.statId = statId;
            this.boostPoint = boostPoint;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(statId);
            writer.WriteShort(boostPoint);
        }
        public override void Deserialize(IDataReader reader)
        {
            statId = reader.ReadSByte();
            if (statId < 0)
                throw new Exception("Forbidden value on statId = " + statId + ", it doesn't respect the following condition : statId < 0");
            boostPoint = reader.ReadShort();
            if (boostPoint < 0)
                throw new Exception("Forbidden value on boostPoint = " + boostPoint + ", it doesn't respect the following condition : boostPoint < 0");
		}
	}
}
