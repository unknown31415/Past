using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class AuthenticationTicketMessage : NetworkMessage
	{
        public string ticket;
        public string lang;
        public override uint Id
        {
        	get { return 110; }
        }
        public AuthenticationTicketMessage()
        {
        }
        public AuthenticationTicketMessage(string ticket, string lang)
        {
            this.ticket = ticket;
            this.lang = lang;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(ticket);
            writer.WriteUTF(lang);
        }
        public override void Deserialize(IDataReader reader)
        {
            ticket = reader.ReadUTF();
            lang = reader.ReadUTF();
		}
	}
}
