using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class SpellUpgradeSuccessMessage : NetworkMessage
	{
        public int spellId;
        public sbyte spellLevel;
        public override uint Id
        {
        	get { return 1201; }
        }
        public SpellUpgradeSuccessMessage()
        {
        }
        public SpellUpgradeSuccessMessage(int spellId, sbyte spellLevel)
        {
            this.spellId = spellId;
            this.spellLevel = spellLevel;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(spellId);
            writer.WriteSByte(spellLevel);
        }
        public override void Deserialize(IDataReader reader)
        {
            spellId = reader.ReadInt();
            spellLevel = reader.ReadSByte();
            if (spellLevel < 1 || spellLevel > 6)
                throw new Exception("Forbidden value on spellLevel = " + spellLevel + ", it doesn't respect the following condition : spellLevel < 1 || spellLevel > 6");
		}
	}
}
