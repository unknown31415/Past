using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class StartupActionsExecuteMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 1302; }
        }
        public StartupActionsExecuteMessage()
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
