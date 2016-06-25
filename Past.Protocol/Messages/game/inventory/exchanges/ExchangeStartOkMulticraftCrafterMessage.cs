using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeStartOkMulticraftCrafterMessage : NetworkMessage
	{
        public sbyte maxCase;
        public int skillId;
        public override uint Id
        {
        	get { return 5818; }
        }
        public ExchangeStartOkMulticraftCrafterMessage()
        {
        }
        public ExchangeStartOkMulticraftCrafterMessage(sbyte maxCase, int skillId)
        {
            this.maxCase = maxCase;
            this.skillId = skillId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(maxCase);
            writer.WriteInt(skillId);
        }
        public override void Deserialize(IDataReader reader)
        {
            maxCase = reader.ReadSByte();
            if (maxCase < 0)
                throw new Exception("Forbidden value on maxCase = " + maxCase + ", it doesn't respect the following condition : maxCase < 0");
            skillId = reader.ReadInt();
            if (skillId < 0)
                throw new Exception("Forbidden value on skillId = " + skillId + ", it doesn't respect the following condition : skillId < 0");
		}
	}
}
