using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameContextCreateErrorMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 6024; }
        }
        public GameContextCreateErrorMessage()
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
