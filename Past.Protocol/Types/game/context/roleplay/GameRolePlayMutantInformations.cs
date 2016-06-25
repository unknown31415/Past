using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class GameRolePlayMutantInformations : GameRolePlayHumanoidInformations
    {
        public sbyte powerLevel;
        public new const short Id = 3;
        public override short TypeId
        {
            get { return Id; }
        }
        public GameRolePlayMutantInformations()
        {
        }
        public GameRolePlayMutantInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, string name, HumanInformations humanoidInfo, sbyte powerLevel) : base(contextualId, look, disposition, name, humanoidInfo)
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
        }
    }
}
