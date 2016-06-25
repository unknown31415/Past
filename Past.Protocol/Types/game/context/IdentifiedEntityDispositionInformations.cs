using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class IdentifiedEntityDispositionInformations : EntityDispositionInformations
	{ 
		public int id;
		public new const short Id = 107;
		public override short TypeId
		{
			get { return Id; }
		}
		public IdentifiedEntityDispositionInformations()
		{
		}
		public IdentifiedEntityDispositionInformations(short cellId, sbyte direction, int id) : base(cellId, direction)
		{
			this.id = id;
		}
		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteInt(id);
		}
		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			id = reader.ReadInt();
		}
	}
}