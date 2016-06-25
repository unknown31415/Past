using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class AbstractGameActionMessage : NetworkMessage
	{
        public short actionId;
        public int sourceId;
        public override uint Id
        {
        	get { return 1000; }
        }
        public AbstractGameActionMessage()
        {
        }
        public AbstractGameActionMessage(short actionId, int sourceId)
        {
            this.actionId = actionId;
            this.sourceId = sourceId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(actionId);
            writer.WriteInt(sourceId);
        }
        public override void Deserialize(IDataReader reader)
        {
            actionId = reader.ReadShort();
            if (actionId < 0)
                throw new Exception("Forbidden value on actionId = " + actionId + ", it doesn't respect the following condition : actionId < 0");
            sourceId = reader.ReadInt();
		}
	}
}
