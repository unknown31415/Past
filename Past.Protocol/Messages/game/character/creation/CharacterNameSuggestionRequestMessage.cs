using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class CharacterNameSuggestionRequestMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 162; }
        }
        public CharacterNameSuggestionRequestMessage()
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
