using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangePlayerRequestMessage : ExchangeRequestMessage
	{
        public int target;
        public override uint Id
        {
        	get { return 5773; }
        }
        public ExchangePlayerRequestMessage()
        {
        }
        public ExchangePlayerRequestMessage(sbyte exchangeType, int target) : base(exchangeType)
        {
            this.target = target;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(target);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            target = reader.ReadInt();
            if (target < 0)
                throw new Exception("Forbidden value on target = " + target + ", it doesn't respect the following condition : target < 0");
		}
	}
}
