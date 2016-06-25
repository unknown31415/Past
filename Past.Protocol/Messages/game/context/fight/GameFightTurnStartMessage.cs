using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameFightTurnStartMessage : NetworkMessage
	{
        public int id;
        public int waitTime;
        public override uint Id
        {
        	get { return 714; }
        }
        public GameFightTurnStartMessage()
        {
        }
        public GameFightTurnStartMessage(int id, int waitTime)
        {
            this.id = id;
            this.waitTime = waitTime;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(id);
            writer.WriteInt(waitTime);
        }
        public override void Deserialize(IDataReader reader)
        {
            id = reader.ReadInt();
            waitTime = reader.ReadInt();
            if (waitTime < 0)
                throw new Exception("Forbidden value on waitTime = " + waitTime + ", it doesn't respect the following condition : waitTime < 0");
		}
	}
}
