using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ObjectsAddedMessage : NetworkMessage
	{
        public ObjectItem[] @object;
        public override uint Id
        {
        	get { return 6033; }
        }
        public ObjectsAddedMessage()
        {
        }
        public ObjectsAddedMessage(ObjectItem[] @object)
        {
            this.@object = @object;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)@object.Length);
            foreach (var entry in @object)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            @object = new ObjectItem[limit];
            for (int i = 0; i < limit; i++)
            {
                 @object[i] = new ObjectItem();
                 @object[i].Deserialize(reader);
            }
		}
	}
}
