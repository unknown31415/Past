using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PrismBalanceResultMessage : NetworkMessage
	{
        public sbyte totalBalanceValue;
        public sbyte subAreaBalanceValue;
        public override uint Id
        {
        	get { return 5841; }
        }
        public PrismBalanceResultMessage()
        {
        }
        public PrismBalanceResultMessage(sbyte totalBalanceValue, sbyte subAreaBalanceValue)
        {
            this.totalBalanceValue = totalBalanceValue;
            this.subAreaBalanceValue = subAreaBalanceValue;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(totalBalanceValue);
            writer.WriteSByte(subAreaBalanceValue);
        }
        public override void Deserialize(IDataReader reader)
        {
            totalBalanceValue = reader.ReadSByte();
            if (totalBalanceValue < 0)
                throw new Exception("Forbidden value on totalBalanceValue = " + totalBalanceValue + ", it doesn't respect the following condition : totalBalanceValue < 0");
            subAreaBalanceValue = reader.ReadSByte();
            if (subAreaBalanceValue < 0)
                throw new Exception("Forbidden value on subAreaBalanceValue = " + subAreaBalanceValue + ", it doesn't respect the following condition : subAreaBalanceValue < 0");
		}
	}
}
