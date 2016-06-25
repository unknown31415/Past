using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ServerStatusUpdateMessage : NetworkMessage
	{
        public GameServerInformations server;
        public override uint Id
        {
        	get { return 50; }
        }
        public ServerStatusUpdateMessage()
        {
        }
        public ServerStatusUpdateMessage(GameServerInformations server)
        {
            this.server = server;
        }
        public override void Serialize(IDataWriter writer)
        {
            server.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            server = new GameServerInformations();
            server.Deserialize(reader);
		}
	}
}
