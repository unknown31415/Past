using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class LifePointsRegenEndMessage : UpdateLifePointsMessage
	{
        public int lifePointsGained;
        public override uint Id
        {
        	get { return 5686; }
        }
        public LifePointsRegenEndMessage()
        {
        }
        public LifePointsRegenEndMessage(int lifePoints, int maxLifePoints, int lifePointsGained) : base(lifePoints, maxLifePoints)
        {
            this.lifePointsGained = lifePointsGained;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(lifePointsGained);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            lifePointsGained = reader.ReadInt();
            if (lifePointsGained < 0)
                throw new Exception("Forbidden value on lifePointsGained = " + lifePointsGained + ", it doesn't respect the following condition : lifePointsGained < 0");
		}
	}
}
