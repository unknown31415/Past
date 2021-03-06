using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildPaddockRemovedMessage : NetworkMessage
	{
        public short worldX;
        public short worldY;
        public override uint Id
        {
        	get { return 5955; }
        }
        public GuildPaddockRemovedMessage()
        {
        }
        public GuildPaddockRemovedMessage(short worldX, short worldY)
        {
            this.worldX = worldX;
            this.worldY = worldY;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(worldX);
            writer.WriteShort(worldY);
        }
        public override void Deserialize(IDataReader reader)
        {
            worldX = reader.ReadShort();
            if (worldX < -255 || worldX > 255)
                throw new Exception("Forbidden value on worldX = " + worldX + ", it doesn't respect the following condition : worldX < -255 || worldX > 255");
            worldY = reader.ReadShort();
            if (worldY < -255 || worldY > 255)
                throw new Exception("Forbidden value on worldY = " + worldY + ", it doesn't respect the following condition : worldY < -255 || worldY > 255");
		}
	}
}
