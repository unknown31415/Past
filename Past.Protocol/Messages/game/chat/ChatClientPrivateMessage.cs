using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ChatClientPrivateMessage : ChatAbstractClientMessage
	{
        public string receiver;
        public override uint Id
        {
        	get { return 851; }
        }
        public ChatClientPrivateMessage()
        {
        }
        public ChatClientPrivateMessage(string content, string receiver) : base(content)
        {
            this.receiver = receiver;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(receiver);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            receiver = reader.ReadUTF();
		}
	}
}
