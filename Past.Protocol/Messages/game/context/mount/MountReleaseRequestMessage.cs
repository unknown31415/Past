using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class MountReleaseRequestMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 5980; }
        }
        public MountReleaseRequestMessage()
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
