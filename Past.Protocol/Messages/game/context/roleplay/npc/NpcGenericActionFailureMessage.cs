using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class NpcGenericActionFailureMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 5900; }
        }
        public NpcGenericActionFailureMessage()
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
