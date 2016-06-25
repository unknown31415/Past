using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ChatServerMessage : ChatAbstractServerMessage
	{
        public int senderId;
        public string senderName;
        public override uint Id
        {
        	get { return 881; }
        }
        public ChatServerMessage()
        {
        }
        public ChatServerMessage(sbyte channel, string content, int timestamp, string fingerprint, int senderId, string senderName) : base(channel, content, timestamp, fingerprint)
        {
            this.senderId = senderId;
            this.senderName = senderName;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(senderId);
            writer.WriteUTF(senderName);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            senderId = reader.ReadInt();
            senderName = reader.ReadUTF();
		}
	}
}
