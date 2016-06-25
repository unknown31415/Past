using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class ProtectedEntityWaitingForHelpInfo
    {
        public int timeLeftBeforeFight;
        public int waitTimeForPlacement;
        public sbyte nbPositionForDefensors;
        public const short Id = 186;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public ProtectedEntityWaitingForHelpInfo()
        {
        }
        public ProtectedEntityWaitingForHelpInfo(int timeLeftBeforeFight, int waitTimeForPlacement, sbyte nbPositionForDefensors)
        {
            this.timeLeftBeforeFight = timeLeftBeforeFight;
            this.waitTimeForPlacement = waitTimeForPlacement;
            this.nbPositionForDefensors = nbPositionForDefensors;
        }
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(timeLeftBeforeFight);
            writer.WriteInt(waitTimeForPlacement);
            writer.WriteSByte(nbPositionForDefensors);
        }
        public virtual void Deserialize(IDataReader reader)
        {
            timeLeftBeforeFight = reader.ReadInt();
            waitTimeForPlacement = reader.ReadInt();
            nbPositionForDefensors = reader.ReadSByte();
            if (nbPositionForDefensors < 0)
                throw new Exception("Forbidden value on nbPositionForDefensors = " + nbPositionForDefensors + ", it doesn't respect the following condition : nbPositionForDefensors < 0");
        }
    }
}

		