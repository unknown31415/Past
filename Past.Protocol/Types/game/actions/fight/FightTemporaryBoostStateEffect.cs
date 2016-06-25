using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class FightTemporaryBoostStateEffect : FightTemporaryBoostEffect
	{ 
		public short stateId;
		public new const short Id = 214;
		public override short TypeId
		{
			get { return Id; }
		}
		public FightTemporaryBoostStateEffect()
		{
		}
		public FightTemporaryBoostStateEffect(int uid, int targetId, short turnDuration, sbyte dispelable, short spellId, short delta, short stateId) : base(uid, targetId, turnDuration, dispelable, spellId, delta)
		{
			this.stateId = stateId;
		}
		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort(stateId);
		}
		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			stateId = reader.ReadShort();
		}
	}
}