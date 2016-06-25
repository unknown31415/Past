using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameActionFightCastRequestMessage : NetworkMessage
	{
        public short spellId;
        public short cellId;
        public override uint Id
        {
        	get { return 1005; }
        }
        public GameActionFightCastRequestMessage()
        {
        }
        public GameActionFightCastRequestMessage(short spellId, short cellId)
        {
            this.spellId = spellId;
            this.cellId = cellId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(spellId);
            writer.WriteShort(cellId);
        }
        public override void Deserialize(IDataReader reader)
        {
            spellId = reader.ReadShort();
            if (spellId < 0)
                throw new Exception("Forbidden value on spellId = " + spellId + ", it doesn't respect the following condition : spellId < 0");
            cellId = reader.ReadShort();
            if (cellId < -1 || cellId > 559)
                throw new Exception("Forbidden value on cellId = " + cellId + ", it doesn't respect the following condition : cellId < -1 || cellId > 559");
		}
	}
}
