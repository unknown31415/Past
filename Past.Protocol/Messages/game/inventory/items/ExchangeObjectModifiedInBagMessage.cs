using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeObjectModifiedInBagMessage : ExchangeObjectMessage
	{
        public ObjectItem @object;
        public override uint Id
        {
        	get { return 6008; }
        }
        public ExchangeObjectModifiedInBagMessage()
        {
        }
        public ExchangeObjectModifiedInBagMessage(bool remote, ObjectItem @object) : base(remote)
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
