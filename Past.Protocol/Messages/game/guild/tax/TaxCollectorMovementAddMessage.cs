using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class TaxCollectorMovementAddMessage : NetworkMessage
	{
        public TaxCollectorInformations informations;
        public override uint Id
        {
        	get { return 5917; }
        }
        public TaxCollectorMovementAddMessage()
        {
        }
        public TaxCollectorMovementAddMessage(TaxCollectorInformations informations)
        {
            this.informations = informations;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(informations.TypeId);
            informations.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            informations = (TaxCollectorInformations)ProtocolTypeManager.GetInstance(reader.ReadUShort());
            informations.Deserialize(reader);
		}
	}
}
