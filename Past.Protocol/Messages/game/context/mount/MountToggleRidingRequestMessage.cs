using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class MountToggleRidingRequestMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 5976; }
        }
        public MountToggleRidingRequestMessage()
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
