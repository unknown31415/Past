using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class AbstractGameActionFightTargetedAbilityMessage : AbstractGameActionMessage
	{
        public short destinationCellId;
        public sbyte critical;
        public bool silentCast;
        public override uint Id
        {
        	get { return 6118; }
        }
        public AbstractGameActionFightTargetedAbilityMessage()
        {
        }
        public AbstractGameActionFightTargetedAbilityMessage(short actionId, int sourceId, short destinationCellId, sbyte critical, bool silentCast) : base(actionId, sourceId)
        {
            this.destinationCellId = destinationCellId;
            this.critical = critical;
            this.silentCast = silentCast;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(destinationCellId);
            writer.WriteSByte(critical);
            writer.WriteBoolean(silentCast);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            destinationCellId = reader.ReadShort();
            if (destinationCellId < -1 || destinationCellId > 559)
                throw new Exception("Forbidden value on destinationCellId = " + destinationCellId + ", it doesn't respect the following condition : destinationCellId < -1 || destinationCellId > 559");
            critical = reader.ReadSByte();
            if (critical < 0)
                throw new Exception("Forbidden value on critical = " + critical + ", it doesn't respect the following condition : critical < 0");
            silentCast = reader.ReadBoolean();
		}
	}
}
