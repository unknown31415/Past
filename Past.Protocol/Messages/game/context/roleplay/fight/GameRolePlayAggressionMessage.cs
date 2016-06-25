using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameRolePlayAggressionMessage : NetworkMessage
	{
        public int attackerId;
        public int defenderId;
        public override uint Id
        {
        	get { return 6073; }
        }
        public GameRolePlayAggressionMessage()
        {
        }
        public GameRolePlayAggressionMessage(int attackerId, int defenderId)
        {
            this.attackerId = attackerId;
            this.defenderId = defenderId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(attackerId);
            writer.WriteInt(defenderId);
        }
        public override void Deserialize(IDataReader reader)
        {
            attackerId = reader.ReadInt();
            if (attackerId < 0)
                throw new Exception("Forbidden value on attackerId = " + attackerId + ", it doesn't respect the following condition : attackerId < 0");
            defenderId = reader.ReadInt();
            if (defenderId < 0)
                throw new Exception("Forbidden value on defenderId = " + defenderId + ", it doesn't respect the following condition : defenderId < 0");
		}
	}
}
