using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class AuthenticationTicketAcceptedMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 111; }
        }
        public AuthenticationTicketAcceptedMessage()
        {
        }
        public override void Serialize(IDataWriter writer)
        {
        }
        public override void Deserialize(IDataReader reader)
        {
		}
	}
}
