using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class AbstractGameActionWithAckMessage : AbstractGameActionMessage
	{
        public short waitAckId;
        public override uint Id
        {
        	get { return 1001; }
        }
        public AbstractGameActionWithAckMessage()
        {
        }
        public AbstractGameActionWithAckMessage(short actionId, int sourceId, short waitAckId) : base(actionId, sourceId)
        {
            this.waitAckId = waitAckId;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(waitAckId);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            waitAckId = reader.ReadShort();
		}
	}
}
