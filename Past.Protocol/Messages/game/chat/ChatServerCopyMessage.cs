using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ChatServerCopyMessage : ChatAbstractServerMessage
	{
        public int receiverId;
        public string receiverName;
        public override uint Id
        {
        	get { return 882; }
        }
        public ChatServerCopyMessage()
        {
        }
        public ChatServerCopyMessage(sbyte channel, string content, int timestamp, string fingerprint, int receiverId, string receiverName) : base(channel, content, timestamp, fingerprint)
        {
            this.receiverId = receiverId;
            this.receiverName = receiverName;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(receiverId);
            writer.WriteUTF(receiverName);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            receiverId = reader.ReadInt();
            if (receiverId < 0)
                throw new Exception("Forbidden value on receiverId = " + receiverId + ", it doesn't respect the following condition : receiverId < 0");
            receiverName = reader.ReadUTF();
		}
	}
}
