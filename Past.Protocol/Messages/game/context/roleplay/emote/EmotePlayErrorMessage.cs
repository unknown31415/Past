using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class EmotePlayErrorMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 5688; }
        }
        public EmotePlayErrorMessage()
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
