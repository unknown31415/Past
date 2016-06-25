using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class GameFightMonsterWithAlignmentInformations : GameFightMonsterInformations
    {
        public ActorAlignmentInformations alignmentInfos;

        public new const short Id = 203;
        public override short TypeId
        {
            get { return Id; }
        }
        public GameFightMonsterWithAlignmentInformations()
        {
        }
        public GameFightMonsterWithAlignmentInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, sbyte teamId, bool alive, GameFightMinimalStats stats, short creatureGenericId, sbyte creatureGrade, ActorAlignmentInformations alignmentInfos) : base(contextualId, look, disposition, teamId, alive, stats, creatureGenericId, creatureGrade)
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
            alignmentInfos = new Types.ActorAlignmentInformations();
            alignmentInfos.Deserialize(reader);
        }
    }
}
