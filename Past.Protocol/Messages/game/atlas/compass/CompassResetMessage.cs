using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class CompassResetMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 5584; }
        }
        public CompassResetMessage()
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
