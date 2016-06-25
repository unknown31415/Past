using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PartyRefuseInvitationMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 5582; }
        }
        public PartyRefuseInvitationMessage()
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
