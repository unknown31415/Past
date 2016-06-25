using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeMultiCraftCrafterCanUseHisRessourcesMessage : NetworkMessage
	{
        public bool allowed;
        public override uint Id
        {
        	get { return 6020; }
        }
        public ExchangeMultiCraftCrafterCanUseHisRessourcesMessage()
        {
        }
        public ExchangeMultiCraftCrafterCanUseHisRessourcesMessage(bool allowed)
        {
            this.allowed = allowed;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(allowed);
        }
        public override void Deserialize(IDataReader reader)
        {
            allowed = reader.ReadBoolean();
		}
	}
}
