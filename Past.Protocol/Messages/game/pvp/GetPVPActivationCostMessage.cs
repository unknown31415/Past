using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GetPVPActivationCostMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 1811; }
        }
        public GetPVPActivationCostMessage()
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
