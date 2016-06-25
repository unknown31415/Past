using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class CharacterBaseInformations : CharacterMinimalPlusLookInformations
    {
        public sbyte breed;
        public bool sex;
        public new const short Id = 45;
        public override short TypeId
        {
            get { return Id; }
        }
        public CharacterBaseInformations()
        {
        }
        public CharacterBaseInformations(int id, string name, byte level, Types.EntityLook entityLook, sbyte breed, bool sex) : base(id, name, level, entityLook)
        {
            this.breed = breed;
            this.sex = sex;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(breed);
            writer.WriteBoolean(sex);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            breed = reader.ReadSByte();
            sex = reader.ReadBoolean();
        }
    }
}
