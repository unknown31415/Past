using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class GameFightMutantInformations : GameFightFighterNamedInformations
    {
        public sbyte powerLevel;
        public new const short Id = 50;
        public override short TypeId
        {
            get { return Id; }
        }
        public GameFightMutantInformations()
        {
        }
        public GameFightMutantInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, sbyte teamId, bool alive, GameFightMinimalStats stats, string name, sbyte powerLevel) : base(contextualId, look, disposition, teamId, alive, stats, name)
        {
            this.powerLevel = powerLevel;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(powerLevel);

        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            powerLevel = reader.ReadSByte();
            if (powerLevel < 0)
                throw new Exception("Forbidden value on powerLevel = " + powerLevel + ", it doesn't respect the following condition : powerLevel < 0");
        }
    }
}
