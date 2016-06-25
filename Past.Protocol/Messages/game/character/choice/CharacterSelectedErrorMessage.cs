using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class CharacterSelectedErrorMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 5836; }
        }
        public CharacterSelectedErrorMessage()
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
