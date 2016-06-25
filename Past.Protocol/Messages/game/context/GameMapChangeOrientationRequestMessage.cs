using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameMapChangeOrientationRequestMessage : NetworkMessage
	{
        public sbyte direction;
        public override uint Id
        {
        	get { return 945; }
        }
        public GameMapChangeOrientationRequestMessage()
        {
        }
        public GameMapChangeOrientationRequestMessage(sbyte direction)
        {
            this.direction = direction;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(direction);
        }
        public override void Deserialize(IDataReader reader)
        {
            direction = reader.ReadSByte();
            if (direction < 0)
                throw new Exception("Forbidden value on direction = " + direction + ", it doesn't respect the following condition : direction < 0");
		}
	}
}
