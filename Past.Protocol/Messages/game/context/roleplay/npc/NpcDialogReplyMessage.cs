using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class NpcDialogReplyMessage : NetworkMessage
	{
        public short replyId;
        public override uint Id
        {
        	get { return 5616; }
        }
        public NpcDialogReplyMessage()
        {
        }
        public NpcDialogReplyMessage(short replyId)
        {
            this.replyId = replyId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(replyId);
        }
        public override void Deserialize(IDataReader reader)
        {
            replyId = reader.ReadShort();
            if (replyId < 0)
                throw new Exception("Forbidden value on replyId = " + replyId + ", it doesn't respect the following condition : replyId < 0");
		}
	}
}
