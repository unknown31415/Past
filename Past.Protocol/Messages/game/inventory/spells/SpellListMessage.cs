using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class SpellListMessage : NetworkMessage
	{
        public bool spellPrevisualization;
        public SpellItem[] spells;
        public override uint Id
        {
        	get { return 1200; }
        }
        public SpellListMessage()
        {
        }
        public SpellListMessage(bool spellPrevisualization, SpellItem[] spells)
        {
            this.spellPrevisualization = spellPrevisualization;
            this.spells = spells;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(spellPrevisualization);
            writer.WriteUShort((ushort)spells.Length);
            foreach (var entry in spells)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            spellPrevisualization = reader.ReadBoolean();
            var limit = reader.ReadUShort();
            spells = new SpellItem[limit];
            for (int i = 0; i < limit; i++)
            {
                 spells[i] = new SpellItem();
                 spells[i].Deserialize(reader);
            }
		}
	}
}
