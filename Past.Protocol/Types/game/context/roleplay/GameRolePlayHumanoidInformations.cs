using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class GameRolePlayHumanoidInformations : GameRolePlayNamedActorInformations
    {
        public HumanInformations humanoidInfo;
        public new const short Id = 159;
        public override short TypeId
        {
            get { return Id; }
        }
        public GameRolePlayHumanoidInformations()
        {
        }
        public GameRolePlayHumanoidInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, string name, HumanInformations humanoidInfo) : base(contextualId, look, disposition, name)
        {
            this.humanoidInfo = humanoidInfo;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(humanoidInfo.TypeId);
            humanoidInfo.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            humanoidInfo = (HumanInformations)ProtocolTypeManager.GetInstance(reader.ReadUShort());
            humanoidInfo.Deserialize(reader);
        }
    }
}
