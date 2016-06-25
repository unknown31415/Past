using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ChatSmileyRequestMessage : NetworkMessage
	{
        public sbyte smileyId;
        public override uint Id
        {
        	get { return 800; }
        }
        public ChatSmileyRequestMessage()
        {
        }
        public ChatSmileyRequestMessage(sbyte smileyId)
        {
            this.smileyId = smileyId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(smileyId);
        }
        public override void Deserialize(IDataReader reader)
        {
            smileyId = reader.ReadSByte();
            if (smileyId < 0)
                throw new Exception("Forbidden value on smileyId = " + smileyId + ", it doesn't respect the following condition : smileyId < 0");
		}
	}
}
