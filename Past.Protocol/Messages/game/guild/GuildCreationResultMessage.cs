using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildCreationResultMessage : NetworkMessage
	{
        public sbyte result;
        public override uint Id
        {
        	get { return 5554; }
        }
        public GuildCreationResultMessage()
        {
        }
        public GuildCreationResultMessage(sbyte result)
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
