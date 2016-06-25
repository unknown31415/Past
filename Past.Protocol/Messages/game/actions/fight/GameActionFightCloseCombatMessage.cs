using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameActionFightCloseCombatMessage : AbstractGameActionFightTargetedAbilityMessage
	{
        public int weaponGenericId;
        public override uint Id
        {
        	get { return 6116; }
        }
        public GameActionFightCloseCombatMessage()
        {
        }
        public GameActionFightCloseCombatMessage(short actionId, int sourceId, short destinationCellId, sbyte critical, bool silentCast, int weaponGenericId) : base(actionId, sourceId, destinationCellId, critical, silentCast)
        {
            this.weaponGenericId = weaponGenericId;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(weaponGenericId);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            weaponGenericId = reader.ReadInt();
            if (weaponGenericId < 0)
                throw new Exception("Forbidden value on weaponGenericId = " + weaponGenericId + ", it doesn't respect the following condition : weaponGenericId < 0");
		}
	}
}
