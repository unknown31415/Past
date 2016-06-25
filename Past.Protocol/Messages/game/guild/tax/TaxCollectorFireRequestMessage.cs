using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class TaxCollectorFireRequestMessage : NetworkMessage
	{
        public int collectorId;
        public override uint Id
        {
        	get { return 5682; }
        }
        public TaxCollectorFireRequestMessage()
        {
        }
        public TaxCollectorFireRequestMessage(int collectorId)
        {
            this.collectorId = collectorId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(collectorId);
        }
        public override void Deserialize(IDataReader reader)
        {
            collectorId = reader.ReadInt();
		}
	}
}
