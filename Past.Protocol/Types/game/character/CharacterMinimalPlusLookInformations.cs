using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class CharacterMinimalPlusLookInformations : CharacterMinimalInformations
    {
        public EntityLook entityLook;
        public new const short Id = 163;
        public override short TypeId
        {
            get { return Id; }
        }
        public CharacterMinimalPlusLookInformations()
        {
        }
        public CharacterMinimalPlusLookInformations(int id, string name, byte level, EntityLook entityLook) : base(id, name, level)
        {
            this.entityLook = entityLook;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            entityLook.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            entityLook = new EntityLook();
            entityLook.Deserialize(reader);
        }
    }
}

