using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeItemPaymentForCraftMessage : NetworkMessage
	{
        public bool onlySuccess;
        public ObjectItemNotInContainer @object;
        public override uint Id
        {
        	get { return 5831; }
        }
        public ExchangeItemPaymentForCraftMessage()
        {
        }
        public ExchangeItemPaymentForCraftMessage(bool onlySuccess, ObjectItemNotInContainer @object)
        {
            this.onlySuccess = onlySuccess;
            this.@object = @object;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(onlySuccess);
            @object.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            onlySuccess = reader.ReadBoolean();
            @object = new ObjectItemNotInContainer();
            @object.Deserialize(reader);
		}
	}
}
