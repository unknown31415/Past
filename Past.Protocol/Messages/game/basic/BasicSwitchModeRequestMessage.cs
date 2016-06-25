using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class BasicSwitchModeRequestMessage : NetworkMessage
	{
        public sbyte mode;
        public override uint Id
        {
        	get { return 6101; }
        }
        public BasicSwitchModeRequestMessage()
        {
        }
        public BasicSwitchModeRequestMessage(sbyte mode)
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
		}
	}
}
