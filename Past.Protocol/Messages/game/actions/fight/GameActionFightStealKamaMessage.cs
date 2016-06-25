using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameActionFightStealKamaMessage : AbstractGameActionMessage
	{
        public int targetId;
        public short amount;
        public override uint Id
        {
        	get { return 5535; }
        }
        public GameActionFightStealKamaMessage()
        {
        }
        public GameActionFightStealKamaMessage(short actionId, int sourceId, int targetId, short amount) : base(actionId, sourceId)
        {
            this.targetId = targetId;
            this.amount = amount;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(targetId);
            writer.WriteShort(amount);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            targetId = reader.ReadInt();
            amount = reader.ReadShort();
            if (amount < 0)
                throw new Exception("Forbidden value on amount = " + amount + ", it doesn't respect the following condition : amount < 0");
		}
	}
}
