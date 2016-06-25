using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class GameRolePlayCharacterInformations : GameRolePlayHumanoidInformations
    {
        public ActorAlignmentInformations alignmentInfos;
        public new const short Id = 36;
        public override short TypeId
        {
            get { return Id; }
        }
        public GameRolePlayCharacterInformations()
        {
        }
        public GameRolePlayCharacterInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, string name, HumanInformations humanoidInfo, ActorAlignmentInformations alignmentInfos) : base(contextualId, look, disposition, name, humanoidInfo)
        {
            this.alignmentInfos = alignmentInfos;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            alignmentInfos.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            alignmentInfos = new ActorAlignmentInformations();
            alignmentInfos.Deserialize(reader);
        }
    }
}
