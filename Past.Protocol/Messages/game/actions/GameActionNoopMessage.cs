using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameActionNoopMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 1002; }
        }
        public GameActionNoopMessage()
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
