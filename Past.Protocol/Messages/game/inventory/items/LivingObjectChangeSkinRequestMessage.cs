using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class LivingObjectChangeSkinRequestMessage : NetworkMessage
	{
        public int livingUID;
        public byte livingPosition;
        public int skinId;
        public override uint Id
        {
        	get { return 5725; }
        }
        public LivingObjectChangeSkinRequestMessage()
        {
        }
        public LivingObjectChangeSkinRequestMessage(int livingUID, byte livingPosition, int skinId)
        {
            this.livingUID = livingUID;
            this.livingPosition = livingPosition;
            this.skinId = skinId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(livingUID);
            writer.WriteByte(livingPosition);
            writer.WriteInt(skinId);
        }
        public override void Deserialize(IDataReader reader)
        {
            livingUID = reader.ReadInt();
            if (livingUID < 0)
                throw new Exception("Forbidden value on livingUID = " + livingUID + ", it doesn't respect the following condition : livingUID < 0");
            livingPosition = reader.ReadByte();
            if (livingPosition < 0 || livingPosition > 255)
                throw new Exception("Forbidden value on livingPosition = " + livingPosition + ", it doesn't respect the following condition : livingPosition < 0 || livingPosition > 255");
            skinId = reader.ReadInt();
            if (skinId < 0)
                throw new Exception("Forbidden value on skinId = " + skinId + ", it doesn't respect the following condition : skinId < 0");
		}
	}
}
