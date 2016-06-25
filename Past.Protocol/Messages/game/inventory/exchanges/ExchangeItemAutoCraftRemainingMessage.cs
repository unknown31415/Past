using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeItemAutoCraftRemainingMessage : NetworkMessage
	{
        public int count;
        public override uint Id
        {
        	get { return 6015; }
        }
        public ExchangeItemAutoCraftRemainingMessage()
        {
        }
        public ExchangeItemAutoCraftRemainingMessage(int count)
        {
            this.count = count;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(count);
        }
        public override void Deserialize(IDataReader reader)
        {
            count = reader.ReadInt();
            if (count < 0)
                throw new Exception("Forbidden value on count = " + count + ", it doesn't respect the following condition : count < 0");
		}
	}
}
