using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class GameRolePlayNamedActorInformations : GameRolePlayActorInformations
    {
        public string name;
        public new const short Id = 154;
        public override short TypeId
        {
            get { return Id; }
        }
        public GameRolePlayNamedActorInformations()
        {
        }
        public GameRolePlayNamedActorInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, string name) : base(contextualId, look, disposition)
        {
            this.name = name;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(name);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            name = reader.ReadUTF();
        }
    }
}
