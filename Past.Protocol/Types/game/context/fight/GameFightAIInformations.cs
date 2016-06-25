using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class GameFightAIInformations : GameFightFighterInformations
    {
        public new const short Id = 151;
        public override short TypeId
        {
            get { return Id; }
        }
        public GameFightAIInformations()
        {
        }
        public GameFightAIInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, sbyte teamId, bool alive, GameFightMinimalStats stats) : base(contextualId, look, disposition, teamId, alive, stats)
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
