using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameMapChangeOrientationMessage : NetworkMessage
	{
        public int id;
        public sbyte direction;
        public override uint Id
        {
        	get { return 946; }
        }
        public GameMapChangeOrientationMessage()
        {
        }
        public GameMapChangeOrientationMessage(int id, sbyte direction)
        {
            this.id = id;
            this.direction = direction;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(id);
            writer.WriteSByte(direction);
        }
        public override void Deserialize(IDataReader reader)
        {
            id = reader.ReadInt();
            direction = reader.ReadSByte();
            if (direction < 0)
                throw new Exception("Forbidden value on direction = " + direction + ", it doesn't respect the following condition : direction < 0");
		}
	}
}
