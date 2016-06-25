using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameContextDestroyMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 201; }
        }
        public GameContextDestroyMessage()
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
