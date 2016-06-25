using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameActionFightTeleportOnSameMapMessage : AbstractGameActionMessage
	{
        public int targetId;
        public short cellId;
        public override uint Id
        {
        	get { return 5528; }
        }
        public GameActionFightTeleportOnSameMapMessage()
        {
        }
        public GameActionFightTeleportOnSameMapMessage(short actionId, int sourceId, int targetId, short cellId) : base(actionId, sourceId)
        {
            this.targetId = targetId;
            this.cellId = cellId;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(targetId);
            writer.WriteShort(cellId);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            targetId = reader.ReadInt();
            cellId = reader.ReadShort();
            if (cellId < -1 || cellId > 559)
                throw new Exception("Forbidden value on cellId = " + cellId + ", it doesn't respect the following condition : cellId < -1 || cellId > 559");
		}
	}
}
