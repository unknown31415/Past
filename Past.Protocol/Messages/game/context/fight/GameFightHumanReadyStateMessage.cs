using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameFightHumanReadyStateMessage : NetworkMessage
	{
        public int characterId;
        public bool isReady;
        public override uint Id
        {
        	get { return 740; }
        }
        public GameFightHumanReadyStateMessage()
        {
        }
        public GameFightHumanReadyStateMessage(int characterId, bool isReady)
        {
            this.characterId = characterId;
            this.isReady = isReady;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(characterId);
            writer.WriteBoolean(isReady);
        }
        public override void Deserialize(IDataReader reader)
        {
            characterId = reader.ReadInt();
            if (characterId < 0)
                throw new Exception("Forbidden value on characterId = " + characterId + ", it doesn't respect the following condition : characterId < 0");
            isReady = reader.ReadBoolean();
		}
	}
}
