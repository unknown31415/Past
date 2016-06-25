using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class MapRunningFightDetailsRequestMessage : NetworkMessage
	{
        public int fightId;
        public override uint Id
        {
        	get { return 5750; }
        }
        public MapRunningFightDetailsRequestMessage()
        {
        }
        public MapRunningFightDetailsRequestMessage(int fightId)
        {
            this.fightId = fightId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(fightId);
        }
        public override void Deserialize(IDataReader reader)
        {
            fightId = reader.ReadInt();
            if (fightId < 0)
                throw new Exception("Forbidden value on fightId = " + fightId + ", it doesn't respect the following condition : fightId < 0");
		}
	}
}
