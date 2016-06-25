using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PartyRefuseInvitationNotificationMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 5596; }
        }
        public PartyRefuseInvitationNotificationMessage()
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
