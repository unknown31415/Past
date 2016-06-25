using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ChatSmileyMessage : NetworkMessage
	{
        public int entityId;
        public sbyte smileyId;
        public override uint Id
        {
        	get { return 801; }
        }
        public ChatSmileyMessage()
        {
        }
        public ChatSmileyMessage(int entityId, sbyte smileyId)
        {
            this.entityId = entityId;
            this.smileyId = smileyId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(entityId);
            writer.WriteSByte(smileyId);
        }
        public override void Deserialize(IDataReader reader)
        {
            entityId = reader.ReadInt();
            smileyId = reader.ReadSByte();
            if (smileyId < 0)
                throw new Exception("Forbidden value on smileyId = " + smileyId + ", it doesn't respect the following condition : smileyId < 0");
		}
	}
}
