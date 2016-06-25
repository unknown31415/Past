using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ChatMessageReportMessage : NetworkMessage
	{
        public string senderName;
        public string content;
        public int timestamp;
        public string fingerprint;
        public sbyte reason;
        public override uint Id
        {
        	get { return 821; }
        }
        public ChatMessageReportMessage()
        {
        }
        public ChatMessageReportMessage(string senderName, string content, int timestamp, string fingerprint, sbyte reason)
        {
            this.senderName = senderName;
            this.content = content;
            this.timestamp = timestamp;
            this.fingerprint = fingerprint;
            this.reason = reason;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(senderName);
            writer.WriteUTF(content);
            writer.WriteInt(timestamp);
            writer.WriteUTF(fingerprint);
            writer.WriteSByte(reason);
        }
        public override void Deserialize(IDataReader reader)
        {
            senderName = reader.ReadUTF();
            content = reader.ReadUTF();
            timestamp = reader.ReadInt();
            if (timestamp < 0)
                throw new Exception("Forbidden value on timestamp = " + timestamp + ", it doesn't respect the following condition : timestamp < 0");
            fingerprint = reader.ReadUTF();
            reason = reader.ReadSByte();
            if (reason < 0)
                throw new Exception("Forbidden value on reason = " + reason + ", it doesn't respect the following condition : reason < 0");
		}
	}
}
