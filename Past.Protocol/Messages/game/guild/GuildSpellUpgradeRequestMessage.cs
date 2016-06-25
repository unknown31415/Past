using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildSpellUpgradeRequestMessage : NetworkMessage
	{
        public int spellId;
        public override uint Id
        {
        	get { return 5699; }
        }
        public GuildSpellUpgradeRequestMessage()
        {
        }
        public GuildSpellUpgradeRequestMessage(int spellId)
        {
            this.spellId = spellId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(spellId);
        }
        public override void Deserialize(IDataReader reader)
        {
            spellId = reader.ReadInt();
            if (spellId < 0)
                throw new Exception("Forbidden value on spellId = " + spellId + ", it doesn't respect the following condition : spellId < 0");
		}
	}
}
