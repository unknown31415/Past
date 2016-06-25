using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameFightTurnEndMessage : NetworkMessage
	{
        public int id;
        public override uint Id
        {
        	get { return 719; }
        }
        public GameFightTurnEndMessage()
        {
        }
        public GameFightTurnEndMessage(int id)
        {
            this.id = id;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(id);
        }
        public override void Deserialize(IDataReader reader)
        {
            id = reader.ReadInt();
		}
	}
}
