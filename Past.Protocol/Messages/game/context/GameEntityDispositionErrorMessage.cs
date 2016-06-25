using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameEntityDispositionErrorMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 5695; }
        }
        public GameEntityDispositionErrorMessage()
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
