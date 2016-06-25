using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class MountEquipedErrorMessage : NetworkMessage
	{
        public sbyte errorType;
        public override uint Id
        {
        	get { return 5963; }
        }
        public MountEquipedErrorMessage()
        {
        }
        public MountEquipedErrorMessage(sbyte errorType)
        {
            this.errorType = errorType;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(errorType);
        }
        public override void Deserialize(IDataReader reader)
        {
            errorType = reader.ReadSByte();
            if (errorType < 0)
                throw new Exception("Forbidden value on errorType = " + errorType + ", it doesn't respect the following condition : errorType < 0");
		}
	}
}
