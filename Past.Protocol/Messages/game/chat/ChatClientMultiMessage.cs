using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ChatClientMultiMessage : ChatAbstractClientMessage
	{
        public sbyte channel;
        public override uint Id
        {
        	get { return 861; }
        }
        public ChatClientMultiMessage()
        {
        }
        public ChatClientMultiMessage(string content, sbyte channel) : base(content)
        {
            this.channel = channel;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(channel);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            channel = reader.ReadSByte();
            if (channel < 0)
                throw new Exception("Forbidden value on channel = " + channel + ", it doesn't respect the following condition : channel < 0");
		}
	}
}
