using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class FightEntityDispositionInformations : EntityDispositionInformations
    {
        public int carryingCharacterId;
        public new const short Id = 217;
        public override short TypeId
        {
            get { return Id; }
        }
        public FightEntityDispositionInformations()
        {
        }
        public FightEntityDispositionInformations(short cellId, sbyte direction, int carryingCharacterId) : base(cellId, direction)
        {
            this.carryingCharacterId = carryingCharacterId;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(carryingCharacterId);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            carryingCharacterId = reader.ReadInt();
        }
    }
}
