using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class ItemDurability
    {
        public short durability;
        public short durabilityMax;
        public const short Id = 168;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public ItemDurability()
        {
        }
        public ItemDurability(short durability, short durabilityMax)
        {
            this.durability = durability;
            this.durabilityMax = durabilityMax;
        }
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteShort(durability);
            writer.WriteShort(durabilityMax);
        }
        public virtual void Deserialize(IDataReader reader)
        {
            durability = reader.ReadShort();
            durabilityMax = reader.ReadShort();
        }
    }
}