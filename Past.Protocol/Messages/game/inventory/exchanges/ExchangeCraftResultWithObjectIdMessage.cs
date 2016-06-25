using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeCraftResultWithObjectIdMessage : ExchangeCraftResultMessage
	{
        public int objectGenericId;
        public override uint Id
        {
        	get { return 6000; }
        }
        public ExchangeCraftResultWithObjectIdMessage()
        {
        }
        public ExchangeCraftResultWithObjectIdMessage(sbyte craftResult, int objectGenericId) : base(craftResult)
        {
            this.objectGenericId = objectGenericId;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(objectGenericId);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            objectGenericId = reader.ReadInt();
            if (objectGenericId < 0)
                throw new Exception("Forbidden value on objectGenericId = " + objectGenericId + ", it doesn't respect the following condition : objectGenericId < 0");
		}
	}
}
