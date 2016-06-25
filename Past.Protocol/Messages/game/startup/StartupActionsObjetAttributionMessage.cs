using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class StartupActionsObjetAttributionMessage : NetworkMessage
	{
        public short actionId;
        public int characterId;
        public override uint Id
        {
        	get { return 1303; }
        }
        public StartupActionsObjetAttributionMessage()
        {
        }
        public StartupActionsObjetAttributionMessage(short actionId, int characterId)
        {
            this.actionId = actionId;
            this.characterId = characterId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(actionId);
            writer.WriteInt(characterId);
        }
        public override void Deserialize(IDataReader reader)
        {
            actionId = reader.ReadShort();
            if (actionId < 0)
                throw new Exception("Forbidden value on actionId = " + actionId + ", it doesn't respect the following condition : actionId < 0");
            characterId = reader.ReadInt();
            if (characterId < 0)
                throw new Exception("Forbidden value on characterId = " + characterId + ", it doesn't respect the following condition : characterId < 0");
		}
	}
}
