using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeErrorMessage : NetworkMessage
	{
        public sbyte errorType;
        public override uint Id
        {
        	get { return 5513; }
        }
        public ExchangeErrorMessage()
        {
        }
        public ExchangeErrorMessage(sbyte errorType)
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
		}
	}
}
