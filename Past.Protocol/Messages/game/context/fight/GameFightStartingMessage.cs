using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameFightStartingMessage : NetworkMessage
	{
        public sbyte fightType;
        public override uint Id
        {
        	get { return 700; }
        }
        public GameFightStartingMessage()
        {
        }
        public GameFightStartingMessage(sbyte fightType)
        {
            this.fightType = fightType;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(fightType);
        }
        public override void Deserialize(IDataReader reader)
        {
            fightType = reader.ReadSByte();
            if (fightType < 0)
                throw new Exception("Forbidden value on fightType = " + fightType + ", it doesn't respect the following condition : fightType < 0");
		}
	}
}
