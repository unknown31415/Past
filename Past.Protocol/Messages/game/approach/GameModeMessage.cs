using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameModeMessage : NetworkMessage
	{
        public sbyte mode;
        public override uint Id
        {
        	get { return 6003; }
        }
        public GameModeMessage()
        {
        }
        public GameModeMessage(sbyte mode)
        {
            this.mode = mode;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(mode);
        }
        public override void Deserialize(IDataReader reader)
        {
            mode = reader.ReadSByte();
            if (mode < 0)
                throw new Exception("Forbidden value on mode = " + mode + ", it doesn't respect the following condition : mode < 0");
		}
	}
}
