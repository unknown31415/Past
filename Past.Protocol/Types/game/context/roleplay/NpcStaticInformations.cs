using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class NpcStaticInformations
    {
        public short npcId;
        public bool sex;
        public short specialArtworkId;
        public const short Id = 155;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public NpcStaticInformations()
        {
        }
        public NpcStaticInformations(short npcId, bool sex, short specialArtworkId)
        {
            this.npcId = npcId;
            this.sex = sex;
            this.specialArtworkId = specialArtworkId;
        }
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteShort(npcId);
            writer.WriteBoolean(sex);
            writer.WriteShort(specialArtworkId);
        }
        public virtual void Deserialize(IDataReader reader)
        {
            npcId = reader.ReadShort();
            if (npcId < 0)
                throw new Exception("Forbidden value on npcId = " + npcId + ", it doesn't respect the following condition : npcId < 0");
            sex = reader.ReadBoolean();
            specialArtworkId = reader.ReadShort();
            if (specialArtworkId < 0)
                throw new Exception("Forbidden value on specialArtworkId = " + specialArtworkId + ", it doesn't respect the following condition : specialArtworkId < 0");
        }
    }
}

