using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class GameFightFighterNamedInformations : GameFightFighterInformations
	{ 
		public string name;
		public new const short Id = 158;
		public override short TypeId
		{
			get { return Id; }
		}
		public GameFightFighterNamedInformations()
		{
		}
		public GameFightFighterNamedInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, sbyte teamId, bool alive, GameFightMinimalStats stats, string name) : base(contextualId, look, disposition, teamId, alive, stats)
		{
			this.name = name;
		}
		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUTF(name);
		}
		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			name = reader.ReadUTF();
		}
	}
}