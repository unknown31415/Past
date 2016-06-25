using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameActionFightReduceDamagesMessage : AbstractGameActionMessage
	{
        public int targetId;
        public int amount;
        public override uint Id
        {
        	get { return 5526; }
        }
        public GameActionFightReduceDamagesMessage()
        {
        }
        public GameActionFightReduceDamagesMessage(short actionId, int sourceId, int targetId, int amount) : base(actionId, sourceId)
        {
            this.targetId = targetId;
            this.amount = amount;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(targetId);
            writer.WriteInt(amount);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            targetId = reader.ReadInt();
            amount = reader.ReadInt();
            if (amount < 0)
                throw new Exception("Forbidden value on amount = " + amount + ", it doesn't respect the following condition : amount < 0");
		}
	}
}
