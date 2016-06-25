using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ObjectAddedMessage : NetworkMessage
	{
        public ObjectItem @object;
        public override uint Id
        {
        	get { return 3025; }
        }
        public ObjectAddedMessage()
        {
        }
        public ObjectAddedMessage(ObjectItem @object)
        {
            this.@object = @object;
        }
        public override void Serialize(IDataWriter writer)
        {
            @object.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            @object = new ObjectItem();
            @object.Deserialize(reader);
		}
	}
}
