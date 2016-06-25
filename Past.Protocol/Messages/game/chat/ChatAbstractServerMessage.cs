using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ChatAbstractServerMessage : NetworkMessage
	{
        public sbyte channel;
        public string content;
        public int timestamp;
        public string fingerprint;
        public override uint Id
        {
        	get { return 880; }
        }
        public ChatAbstractServerMessage()
        {
        }
        public ChatAbstractServerMessage(sbyte channel, string content, int timestamp, string fingerprint)
        {
            this.channel = channel;
            this.content = content;
            this.timestamp = timestamp;
            this.fingerprint = fingerprint;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(channel);
            writer.WriteUTF(content);
            writer.WriteInt(timestamp);
            writer.WriteUTF(fingerprint);
        }
        public override void Deserialize(IDataReader reader)
        {
            channel = reader.ReadSByte();
            if (channel < 0)
                throw new Exception("Forbidden value on channel = " + channel + ", it doesn't respect the following condition : channel < 0");
            content = reader.ReadUTF();
            timestamp = reader.ReadInt();
            if (timestamp < 0)
                throw new Exception("Forbidden value on timestamp = " + timestamp + ", it doesn't respect the following condition : timestamp < 0");
            fingerprint = reader.ReadUTF();
		}
	}
}
