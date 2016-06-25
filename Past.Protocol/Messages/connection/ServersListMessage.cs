using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ServersListMessage : NetworkMessage
	{
        public GameServerInformations[] servers;
        public override uint Id
        {
        	get { return 30; }
        }
        public ServersListMessage()
        {
        }
        public ServersListMessage(GameServerInformations[] servers)
        {
            this.servers = servers;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)servers.Length);
            foreach (var entry in servers)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            servers = new GameServerInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 servers[i] = new GameServerInformations();
                 servers[i].Deserialize(reader);
            }
		}
	}
}
