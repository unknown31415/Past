using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameFightStartMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 712; }
        }
        public GameFightStartMessage()
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
