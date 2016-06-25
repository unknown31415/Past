using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PrismAttackRequestMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 6042; }
        }
        public PrismAttackRequestMessage()
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
