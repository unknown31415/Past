using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class LifePointsRegenBeginMessage : NetworkMessage
	{
        public byte regenRate;
        public override uint Id
        {
        	get { return 5684; }
        }
        public LifePointsRegenBeginMessage()
        {
        }
        public LifePointsRegenBeginMessage(byte regenRate)
        {
            this.regenRate = regenRate;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(regenRate);
        }
        public override void Deserialize(IDataReader reader)
        {
            regenRate = reader.ReadByte();
            if (regenRate < 0 || regenRate > 255)
                throw new Exception("Forbidden value on regenRate = " + regenRate + ", it doesn't respect the following condition : regenRate < 0 || regenRate > 255");
		}
	}
}
