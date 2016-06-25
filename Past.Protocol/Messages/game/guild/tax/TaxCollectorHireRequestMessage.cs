using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class TaxCollectorHireRequestMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 5681; }
        }
        public TaxCollectorHireRequestMessage()
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
