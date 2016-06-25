using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeRequestOnTaxCollectorMessage : NetworkMessage
	{
        public int taxCollectorId;
        public override uint Id
        {
        	get { return 5779; }
        }
        public ExchangeRequestOnTaxCollectorMessage()
        {
        }
        public ExchangeRequestOnTaxCollectorMessage(int taxCollectorId)
        {
            this.taxCollectorId = taxCollectorId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(taxCollectorId);
        }
        public override void Deserialize(IDataReader reader)
        {
            taxCollectorId = reader.ReadInt();
		}
	}
}
