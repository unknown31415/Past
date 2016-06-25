using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ChatAbstractClientMessage : NetworkMessage
	{
        public string content;
        public override uint Id
        {
        	get { return 850; }
        }
        public ChatAbstractClientMessage()
        {
        }
        public ChatAbstractClientMessage(string content)
        {
            this.content = content;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(content);
        }
        public override void Deserialize(IDataReader reader)
        {
            content = reader.ReadUTF();
		}
	}
}
