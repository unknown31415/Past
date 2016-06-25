using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class CharacterNameSuggestionSuccessMessage : NetworkMessage
	{
        public string suggestion;
        public override uint Id
        {
        	get { return 5544; }
        }
        public CharacterNameSuggestionSuccessMessage()
        {
        }
        public CharacterNameSuggestionSuccessMessage(string suggestion)
        {
            this.suggestion = suggestion;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(suggestion);
        }
        public override void Deserialize(IDataReader reader)
        {
            suggestion = reader.ReadUTF();
		}
	}
}
