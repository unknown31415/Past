using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class CharacterLevelUpMessage : NetworkMessage
	{
        public byte newLevel;
        public override uint Id
        {
        	get { return 5670; }
        }
        public CharacterLevelUpMessage()
        {
        }
        public CharacterLevelUpMessage(byte newLevel)
        {
            this.newLevel = newLevel;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(newLevel);
        }
        public override void Deserialize(IDataReader reader)
        {
            newLevel = reader.ReadByte();
            if (newLevel < 2 || newLevel > 200)
                throw new Exception("Forbidden value on newLevel = " + newLevel + ", it doesn't respect the following condition : newLevel < 2 || newLevel > 200");
		}
	}
}
