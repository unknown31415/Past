using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class NpcDialogQuestionMessage : NetworkMessage
	{
        public short messageId;
        public string[] dialogParams;
        public short[] visibleReplies;
        public override uint Id
        {
        	get { return 5617; }
        }
        public NpcDialogQuestionMessage()
        {
        }
        public NpcDialogQuestionMessage(short messageId, string[] dialogParams, short[] visibleReplies)
        {
            this.messageId = messageId;
            this.dialogParams = dialogParams;
            this.visibleReplies = visibleReplies;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(messageId);
            writer.WriteUShort((ushort)dialogParams.Length);
            foreach (var entry in dialogParams)
            {
                 writer.WriteUTF(entry);
            }
            writer.WriteUShort((ushort)visibleReplies.Length);
            foreach (var entry in visibleReplies)
            {
                 writer.WriteShort(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            messageId = reader.ReadShort();
            if (messageId < 0)
                throw new Exception("Forbidden value on messageId = " + messageId + ", it doesn't respect the following condition : messageId < 0");
            var limit = reader.ReadUShort();
            dialogParams = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                 dialogParams[i] = reader.ReadUTF();
            }
            limit = reader.ReadUShort();
            visibleReplies = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 visibleReplies[i] = reader.ReadShort();
            }
		}
	}
}
