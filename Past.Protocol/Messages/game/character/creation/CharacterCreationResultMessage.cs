using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class CharacterCreationResultMessage : NetworkMessage
	{
        public sbyte result;
        public override uint Id
        {
        	get { return 161; }
        }
        public CharacterCreationResultMessage()
        {
        }
        public CharacterCreationResultMessage(sbyte result)
        {
            this.result = result;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(result);
        }
        public override void Deserialize(IDataReader reader)
        {
            result = reader.ReadSByte();
            if (result < 0)
                throw new Exception("Forbidden value on result = " + result + ", it doesn't respect the following condition : result < 0");
		}
	}
}
