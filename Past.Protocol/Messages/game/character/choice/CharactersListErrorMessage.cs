using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class CharactersListErrorMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 5545; }
        }
        public CharactersListErrorMessage()
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
