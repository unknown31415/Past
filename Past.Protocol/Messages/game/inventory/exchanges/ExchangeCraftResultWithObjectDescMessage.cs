using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeCraftResultWithObjectDescMessage : ExchangeCraftResultMessage
	{
        public ObjectItemMinimalInformation objectInfo;
        public override uint Id
        {
        	get { return 5999; }
        }
        public ExchangeCraftResultWithObjectDescMessage()
        {
        }
        public ExchangeCraftResultWithObjectDescMessage(sbyte craftResult, ObjectItemMinimalInformation objectInfo) : base(craftResult)
        {
            this.objectInfo = objectInfo;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            objectInfo.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            objectInfo = new ObjectItemMinimalInformation();
            objectInfo.Deserialize(reader);
		}
	}
}
