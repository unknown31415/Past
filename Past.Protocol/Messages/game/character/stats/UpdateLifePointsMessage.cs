using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class UpdateLifePointsMessage : NetworkMessage
	{
        public int lifePoints;
        public int maxLifePoints;
        public override uint Id
        {
        	get { return 5658; }
        }
        public UpdateLifePointsMessage()
        {
        }
        public UpdateLifePointsMessage(int lifePoints, int maxLifePoints)
        {
            this.lifePoints = lifePoints;
            this.maxLifePoints = maxLifePoints;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(lifePoints);
            writer.WriteInt(maxLifePoints);
        }
        public override void Deserialize(IDataReader reader)
        {
            lifePoints = reader.ReadInt();
            if (lifePoints < 0)
                throw new Exception("Forbidden value on lifePoints = " + lifePoints + ", it doesn't respect the following condition : lifePoints < 0");
            maxLifePoints = reader.ReadInt();
            if (maxLifePoints < 0)
                throw new Exception("Forbidden value on maxLifePoints = " + maxLifePoints + ", it doesn't respect the following condition : maxLifePoints < 0");
		}
	}
}
