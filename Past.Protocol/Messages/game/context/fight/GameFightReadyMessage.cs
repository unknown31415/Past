using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameFightReadyMessage : NetworkMessage
	{
        public bool isReady;
        public override uint Id
        {
        	get { return 708; }
        }
        public GameFightReadyMessage()
        {
        }
        public GameFightReadyMessage(bool isReady)
        {
            this.isReady = isReady;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(isReady);
        }
        public override void Deserialize(IDataReader reader)
        {
            isReady = reader.ReadBoolean();
		}
	}
}
