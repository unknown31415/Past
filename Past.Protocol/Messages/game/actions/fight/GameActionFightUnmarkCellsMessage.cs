using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameActionFightUnmarkCellsMessage : AbstractGameActionMessage
	{
        public short markId;
        public override uint Id
        {
        	get { return 5570; }
        }
        public GameActionFightUnmarkCellsMessage()
        {
        }
        public GameActionFightUnmarkCellsMessage(short actionId, int sourceId, short markId) : base(actionId, sourceId)
        {
            this.markId = markId;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(markId);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            markId = reader.ReadShort();
		}
	}
}
