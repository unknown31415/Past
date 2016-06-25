using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class MountUnSetMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 5982; }
        }
        public MountUnSetMessage()
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
