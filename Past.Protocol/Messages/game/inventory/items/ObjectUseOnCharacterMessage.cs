using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ObjectUseOnCharacterMessage : ObjectUseMessage
	{
        public int characterId;
        public override uint Id
        {
        	get { return 3003; }
        }
        public ObjectUseOnCharacterMessage()
        {
        }
        public ObjectUseOnCharacterMessage(int objectUID, int characterId) : base(objectUID)
        {
            this.characterId = characterId;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(characterId);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            characterId = reader.ReadInt();
            if (characterId < 0)
                throw new Exception("Forbidden value on characterId = " + characterId + ", it doesn't respect the following condition : characterId < 0");
		}
	}
}
