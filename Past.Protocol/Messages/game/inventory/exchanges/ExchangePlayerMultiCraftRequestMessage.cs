using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangePlayerMultiCraftRequestMessage : ExchangeRequestMessage
	{
        public int target;
        public int skillId;
        public override uint Id
        {
        	get { return 5784; }
        }
        public ExchangePlayerMultiCraftRequestMessage()
        {
        }
        public ExchangePlayerMultiCraftRequestMessage(sbyte exchangeType, int target, int skillId) : base(exchangeType)
        {
            this.target = target;
            this.skillId = skillId;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(target);
            writer.WriteInt(skillId);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            target = reader.ReadInt();
            if (target < 0)
                throw new Exception("Forbidden value on target = " + target + ", it doesn't respect the following condition : target < 0");
            skillId = reader.ReadInt();
            if (skillId < 0)
                throw new Exception("Forbidden value on skillId = " + skillId + ", it doesn't respect the following condition : skillId < 0");
		}
	}
}
