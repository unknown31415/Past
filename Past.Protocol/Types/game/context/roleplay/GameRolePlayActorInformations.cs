using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class GameRolePlayActorInformations : GameContextActorInformations
    {
        public new const short Id = 141;
        public override short TypeId
        {
            get { return Id; }
        }
        public GameRolePlayActorInformations()
        {
        }
        public GameRolePlayActorInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition) : base(contextualId, look, disposition)
        {
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }
    }
}
