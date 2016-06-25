using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class CharacterReplayRequestMessage : NetworkMessage
	{
        public int characterId;
        public override uint Id
        {
        	get { return 167; }
        }
        public CharacterReplayRequestMessage()
        {
        }
        public CharacterReplayRequestMessage(int characterId)
        {
            this.characterId = characterId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(characterId);
        }
        public override void Deserialize(IDataReader reader)
        {
            characterId = reader.ReadInt();
            if (characterId < 0)
                throw new Exception("Forbidden value on characterId = " + characterId + ", it doesn't respect the following condition : characterId < 0");
		}
	}
}
