using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class FightTemporaryBoostWeaponDamagesEffect : FightTemporaryBoostEffect
	{ 
		public short weaponTypeId;
		public new const short Id = 211;
		public override short TypeId
		{
			get { return Id; }
		}
		public FightTemporaryBoostWeaponDamagesEffect()
		{
		}
		public FightTemporaryBoostWeaponDamagesEffect(int uid, int targetId, short turnDuration, sbyte dispelable, short spellId, short delta, short weaponTypeId) : base(uid, targetId, turnDuration, dispelable, spellId, delta)
		{
			this.weaponTypeId = weaponTypeId;
		}
		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort(weaponTypeId);
		}
		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			weaponTypeId = reader.ReadShort();
		}
	}
}