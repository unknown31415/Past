using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class SpellUpgradeRequestMessage : NetworkMessage
	{
        public short spellId;
        public override uint Id
        {
        	get { return 5608; }
        }
        public SpellUpgradeRequestMessage()
        {
        }
        public SpellUpgradeRequestMessage(short spellId)
        {
            this.spellId = spellId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(spellId);
        }
        public override void Deserialize(IDataReader reader)
        {
            spellId = reader.ReadShort();
            if (spellId < 0)
                throw new Exception("Forbidden value on spellId = " + spellId + ", it doesn't respect the following condition : spellId < 0");
		}
	}
}
