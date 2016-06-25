using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameMapMovementConfirmMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 952; }
        }
        public GameMapMovementConfirmMessage()
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
