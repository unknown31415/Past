using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameFightOptionToggleMessage : NetworkMessage
	{
        public sbyte option;
        public override uint Id
        {
        	get { return 707; }
        }
        public GameFightOptionToggleMessage()
        {
        }
        public GameFightOptionToggleMessage(sbyte option)
        {
            this.option = option;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(option);
        }
        public override void Deserialize(IDataReader reader)
        {
            option = reader.ReadSByte();
            if (option < 0)
                throw new Exception("Forbidden value on option = " + option + ", it doesn't respect the following condition : option < 0");
		}
	}
}
