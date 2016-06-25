using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ChatClientMultiWithObjectMessage : ChatClientMultiMessage
	{
        public ObjectItem[] objects;
        public override uint Id
        {
        	get { return 862; }
        }
        public ChatClientMultiWithObjectMessage()
        {
        }
        public ChatClientMultiWithObjectMessage(string content, sbyte channel, ObjectItem[] objects) : base(content, channel)
        {
            this.objects = objects;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort((ushort)objects.Length);
            foreach (var entry in objects)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadUShort();
            objects = new ObjectItem[limit];
            for (int i = 0; i < limit; i++)
            {
                 objects[i] = new ObjectItem();
                 objects[i].Deserialize(reader);
            }
		}
	}
}
