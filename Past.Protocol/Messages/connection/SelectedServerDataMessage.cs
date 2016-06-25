using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class SelectedServerDataMessage : NetworkMessage
	{
        public short serverId;
        public string address;
        public ushort port;
        public bool canCreateNewCharacter;
        public string ticket;
        public override uint Id
        {
        	get { return 42; }
        }
        public SelectedServerDataMessage()
        {
        }
        public SelectedServerDataMessage(short serverId, string address, ushort port, bool canCreateNewCharacter, string ticket)
        {
            this.serverId = serverId;
            this.address = address;
            this.port = port;
            this.canCreateNewCharacter = canCreateNewCharacter;
            this.ticket = ticket;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(serverId);
            writer.WriteUTF(address);
            writer.WriteUShort(port);
            writer.WriteBoolean(canCreateNewCharacter);
            writer.WriteUTF(ticket);
        }
        public override void Deserialize(IDataReader reader)
        {
            serverId = reader.ReadShort();
            address = reader.ReadUTF();
            port = reader.ReadUShort();
            if (port < 0 || port > 65535)
                throw new Exception("Forbidden value on port = " + port + ", it doesn't respect the following condition : port < 0 || port > 65535");
            canCreateNewCharacter = reader.ReadBoolean();
            ticket = reader.ReadUTF();
		}
	}
}
