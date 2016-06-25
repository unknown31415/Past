using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PartyAcceptInvitationMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 5580; }
        }
        public PartyAcceptInvitationMessage()
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
