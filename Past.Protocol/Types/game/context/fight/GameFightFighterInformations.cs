using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class GameFightFighterInformations : GameContextActorInformations
    {
        public sbyte teamId;
        public bool alive;
        public GameFightMinimalStats stats;
        public new const short Id = 143;
        public override short TypeId
        {
            get { return Id; }
        }
        public GameFightFighterInformations()
        {
        }
        public GameFightFighterInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, sbyte teamId, bool alive, GameFightMinimalStats stats) : base(contextualId, look, disposition)
        {
            this.teamId = teamId;
            this.alive = alive;
            this.stats = stats;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(teamId);
            writer.WriteBoolean(alive);
            stats.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            teamId = reader.ReadSByte();
            if (teamId < 0)
                throw new Exception("Forbidden value on teamId = " + teamId + ", it doesn't respect the following condition : teamId < 0");
            alive = reader.ReadBoolean();
            stats = new GameFightMinimalStats();
            stats.Deserialize(reader);
        }
    }
}
