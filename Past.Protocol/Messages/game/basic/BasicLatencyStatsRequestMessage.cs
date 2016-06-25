using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class BasicLatencyStatsRequestMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 5816; }
        }
        public BasicLatencyStatsRequestMessage()
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
