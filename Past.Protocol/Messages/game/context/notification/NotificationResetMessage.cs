using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class NotificationResetMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 6089; }
        }
        public NotificationResetMessage()
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
