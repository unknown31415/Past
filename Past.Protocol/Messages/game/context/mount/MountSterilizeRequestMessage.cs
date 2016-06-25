using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class MountSterilizeRequestMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 5962; }
        }
        public MountSterilizeRequestMessage()
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
