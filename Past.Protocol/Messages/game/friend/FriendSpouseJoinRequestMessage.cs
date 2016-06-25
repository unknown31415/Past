using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class FriendSpouseJoinRequestMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 5604; }
        }
        public FriendSpouseJoinRequestMessage()
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
