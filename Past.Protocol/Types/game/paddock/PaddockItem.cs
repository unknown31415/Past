using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class PaddockItem : ObjectItemInRolePlay
    {
        public ItemDurability durability;
        public new const short Id = 185;
        public override short TypeId
        {
            get { return Id; }
        }
        public PaddockItem()
        {
        }
        public PaddockItem(short cellId, short objectGID, ItemDurability durability) : base(cellId, objectGID)
        {
            this.durability = durability;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            durability.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            durability = new ItemDurability();
            durability.Deserialize(reader);
        }
    }
}