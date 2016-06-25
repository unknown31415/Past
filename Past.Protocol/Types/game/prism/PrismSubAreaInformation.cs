using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class PrismSubAreaInformation
    {
        public bool isInFight;
        public bool isFightable;
        public int subId;
        public sbyte alignment;
        public int mapId;
        public const short Id = 142;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public PrismSubAreaInformation()
        {
        }
        public PrismSubAreaInformation(bool isInFight, bool isFightable, int subId, sbyte alignment, int mapId)
        {
            this.isInFight = isInFight;
            this.isFightable = isFightable;
            this.subId = subId;
            this.alignment = alignment;
            this.mapId = mapId;
        }
        public virtual void Serialize(IDataWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, isInFight);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, isFightable);
            writer.WriteByte(flag1);
            writer.WriteInt(subId);
            writer.WriteSByte(alignment);
            writer.WriteInt(mapId);
        }
        public virtual void Deserialize(IDataReader reader)
        {
            byte flag1 = reader.ReadByte();
            isInFight = BooleanByteWrapper.GetFlag(flag1, 0);
            isFightable = BooleanByteWrapper.GetFlag(flag1, 1);
            subId = reader.ReadInt();
            if (subId < 0)
                throw new Exception("Forbidden value on subId = " + subId + ", it doesn't respect the following condition : subId < 0");
            alignment = reader.ReadSByte();
            if (alignment < 0)
                throw new Exception("Forbidden value on alignment = " + alignment + ", it doesn't respect the following condition : alignment < 0");
            mapId = reader.ReadInt();
            if (mapId < 0)
                throw new Exception("Forbidden value on mapId = " + mapId + ", it doesn't respect the following condition : mapId < 0");
        }
    }
}