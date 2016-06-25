using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeOnHumanVendorRequestMessage : NetworkMessage
	{
        public int humanVendorId;
        public int humanVendorCell;
        public override uint Id
        {
        	get { return 5772; }
        }
        public ExchangeOnHumanVendorRequestMessage()
        {
        }
        public ExchangeOnHumanVendorRequestMessage(int humanVendorId, int humanVendorCell)
        {
            this.humanVendorId = humanVendorId;
            this.humanVendorCell = humanVendorCell;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(humanVendorId);
            writer.WriteInt(humanVendorCell);
        }
        public override void Deserialize(IDataReader reader)
        {
            humanVendorId = reader.ReadInt();
            if (humanVendorId < 0)
                throw new Exception("Forbidden value on humanVendorId = " + humanVendorId + ", it doesn't respect the following condition : humanVendorId < 0");
            humanVendorCell = reader.ReadInt();
            if (humanVendorCell < 0)
                throw new Exception("Forbidden value on humanVendorCell = " + humanVendorCell + ", it doesn't respect the following condition : humanVendorCell < 0");
		}
	}
}
