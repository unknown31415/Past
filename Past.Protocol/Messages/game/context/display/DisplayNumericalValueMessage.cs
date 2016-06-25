using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class DisplayNumericalValueMessage : NetworkMessage
	{
        public int entityId;
        public int value;
        public sbyte type;
        public override uint Id
        {
        	get { return 5808; }
        }
        public DisplayNumericalValueMessage()
        {
        }
        public DisplayNumericalValueMessage(int entityId, int value, sbyte type)
        {
            this.entityId = entityId;
            this.value = value;
            this.type = type;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(entityId);
            writer.WriteInt(value);
            writer.WriteSByte(type);
        }
        public override void Deserialize(IDataReader reader)
        {
            entityId = reader.ReadInt();
            value = reader.ReadInt();
            type = reader.ReadSByte();
            if (type < 0)
                throw new Exception("Forbidden value on type = " + type + ", it doesn't respect the following condition : type < 0");
		}
	}
}
