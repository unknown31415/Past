using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeObjectModifiedMessage : ExchangeObjectMessage
	{
        public ObjectItem @object;
        public override uint Id
        {
        	get { return 5519; }
        }
        public ExchangeObjectModifiedMessage()
        {
        }
        public ExchangeObjectModifiedMessage(bool remote, ObjectItem @object) : base(remote)
        {
            this.@object = @object;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            @object.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            @object = new ObjectItem();
            @object.Deserialize(reader);
		}
	}
}
