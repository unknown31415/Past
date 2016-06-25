using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class MapFightCountMessage : NetworkMessage
	{
        public short fightCount;
        public override uint Id
        {
        	get { return 210; }
        }
        public MapFightCountMessage()
        {
        }
        public MapFightCountMessage(short fightCount)
        {
            this.fightCount = fightCount;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(fightCount);
        }
        public override void Deserialize(IDataReader reader)
        {
            fightCount = reader.ReadShort();
            if (fightCount < 0)
                throw new Exception("Forbidden value on fightCount = " + fightCount + ", it doesn't respect the following condition : fightCount < 0");
		}
	}
}
