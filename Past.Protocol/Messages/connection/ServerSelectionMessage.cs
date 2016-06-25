using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ServerSelectionMessage : NetworkMessage
	{
        public short serverId;
        public override uint Id
        {
        	get { return 40; }
        }
        public ServerSelectionMessage()
        {
        }
        public ServerSelectionMessage(short serverId)
        {
            this.serverId = serverId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(serverId);
        }
        public override void Deserialize(IDataReader reader)
        {
            serverId = reader.ReadShort();
		}
	}
}
