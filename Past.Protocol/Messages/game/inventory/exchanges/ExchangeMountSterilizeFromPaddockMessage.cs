using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeMountSterilizeFromPaddockMessage : NetworkMessage
	{
        public string name;
        public short worldX;
        public short worldY;
        public string sterilizator;
        public override uint Id
        {
        	get { return 6056; }
        }
        public ExchangeMountSterilizeFromPaddockMessage()
        {
        }
        public ExchangeMountSterilizeFromPaddockMessage(string name, short worldX, short worldY, string sterilizator)
        {
            this.name = name;
            this.worldX = worldX;
            this.worldY = worldY;
            this.sterilizator = sterilizator;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(name);
            writer.WriteShort(worldX);
            writer.WriteShort(worldY);
            writer.WriteUTF(sterilizator);
        }
        public override void Deserialize(IDataReader reader)
        {
            name = reader.ReadUTF();
            worldX = reader.ReadShort();
            if (worldX < -255 || worldX > 255)
                throw new Exception("Forbidden value on worldX = " + worldX + ", it doesn't respect the following condition : worldX < -255 || worldX > 255");
            worldY = reader.ReadShort();
            if (worldY < -255 || worldY > 255)
                throw new Exception("Forbidden value on worldY = " + worldY + ", it doesn't respect the following condition : worldY < -255 || worldY > 255");
            sterilizator = reader.ReadUTF();
		}
	}
}
