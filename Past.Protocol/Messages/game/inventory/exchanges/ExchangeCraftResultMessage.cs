using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeCraftResultMessage : NetworkMessage
	{
        public sbyte craftResult;
        public override uint Id
        {
        	get { return 5790; }
        }
        public ExchangeCraftResultMessage()
        {
        }
        public ExchangeCraftResultMessage(sbyte craftResult)
        {
            this.craftResult = craftResult;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(craftResult);
        }
        public override void Deserialize(IDataReader reader)
        {
            craftResult = reader.ReadSByte();
            if (craftResult < 0)
                throw new Exception("Forbidden value on craftResult = " + craftResult + ", it doesn't respect the following condition : craftResult < 0");
		}
	}
}
