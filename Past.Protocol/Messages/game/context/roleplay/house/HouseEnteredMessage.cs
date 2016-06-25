using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class HouseEnteredMessage : NetworkMessage
	{
        public int ownerId;
        public string ownerName;
        public uint price;
        public bool isLocked;
        public short worldX;
        public short worldY;
        public short modelId;
        public override uint Id
        {
        	get { return 5860; }
        }
        public HouseEnteredMessage()
        {
        }
        public HouseEnteredMessage(int ownerId, string ownerName, uint price, bool isLocked, short worldX, short worldY, short modelId)
        {
            this.ownerId = ownerId;
            this.ownerName = ownerName;
            this.price = price;
            this.isLocked = isLocked;
            this.worldX = worldX;
            this.worldY = worldY;
            this.modelId = modelId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(ownerId);
            writer.WriteUTF(ownerName);
            writer.WriteUInt(price);
            writer.WriteBoolean(isLocked);
            writer.WriteShort(worldX);
            writer.WriteShort(worldY);
            writer.WriteShort(modelId);
        }
        public override void Deserialize(IDataReader reader)
        {
            ownerId = reader.ReadInt();
            ownerName = reader.ReadUTF();
            price = reader.ReadUInt();
            if (price < 0 || price > 4294967295)
                throw new Exception("Forbidden value on price = " + price + ", it doesn't respect the following condition : price < 0 || price > 4294967295");
            isLocked = reader.ReadBoolean();
            worldX = reader.ReadShort();
            if (worldX < -255 || worldX > 255)
                throw new Exception("Forbidden value on worldX = " + worldX + ", it doesn't respect the following condition : worldX < -255 || worldX > 255");
            worldY = reader.ReadShort();
            if (worldY < -255 || worldY > 255)
                throw new Exception("Forbidden value on worldY = " + worldY + ", it doesn't respect the following condition : worldY < -255 || worldY > 255");
            modelId = reader.ReadShort();
            if (modelId < 0)
                throw new Exception("Forbidden value on modelId = " + modelId + ", it doesn't respect the following condition : modelId < 0");
		}
	}
}
