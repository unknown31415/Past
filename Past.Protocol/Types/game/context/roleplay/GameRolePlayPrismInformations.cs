using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class GameRolePlayPrismInformations : GameRolePlayActorInformations
    {
        public ActorAlignmentInformations alignInfos;
        public new const short Id = 161;
        public override short TypeId
        {
            get { return Id; }
        }
        public GameRolePlayPrismInformations()
        {
        }
        public GameRolePlayPrismInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, ActorAlignmentInformations alignInfos) : base(contextualId, look, disposition)
        {
            this.alignInfos = alignInfos;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            alignInfos.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            alignInfos = new ActorAlignmentInformations();
            alignInfos.Deserialize(reader);
        }
    }
}
