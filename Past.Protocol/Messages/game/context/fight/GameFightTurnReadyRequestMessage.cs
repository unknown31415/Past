using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameFightTurnReadyRequestMessage : NetworkMessage
	{
        public int id;
        public override uint Id
        {
        	get { return 715; }
        }
        public GameFightTurnReadyRequestMessage()
        {
        }
        public GameFightTurnReadyRequestMessage(int id)
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
