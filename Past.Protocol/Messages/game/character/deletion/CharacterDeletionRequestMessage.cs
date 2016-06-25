using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class CharacterDeletionRequestMessage : NetworkMessage
	{
        public int characterId;
        public string secretAnswerHash;
        public override uint Id
        {
        	get { return 165; }
        }
        public CharacterDeletionRequestMessage()
        {
        }
        public CharacterDeletionRequestMessage(int characterId, string secretAnswerHash)
        {
            this.characterId = characterId;
            this.secretAnswerHash = secretAnswerHash;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(characterId);
            writer.WriteUTF(secretAnswerHash);
        }
        public override void Deserialize(IDataReader reader)
        {
            characterId = reader.ReadInt();
            if (characterId < 0)
                throw new Exception("Forbidden value on characterId = " + characterId + ", it doesn't respect the following condition : characterId < 0");
            secretAnswerHash = reader.ReadUTF();
		}
	}
}
