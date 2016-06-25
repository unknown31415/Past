using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeBidHousePriceMessage : NetworkMessage
	{
        public int genId;
        public override uint Id
        {
        	get { return 5805; }
        }
        public ExchangeBidHousePriceMessage()
        {
        }
        public ExchangeBidHousePriceMessage(int genId)
        {
            this.genId = genId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(genId);
        }
        public override void Deserialize(IDataReader reader)
        {
            genId = reader.ReadInt();
            if (genId < 0)
                throw new Exception("Forbidden value on genId = " + genId + ", it doesn't respect the following condition : genId < 0");
		}
	}
}
