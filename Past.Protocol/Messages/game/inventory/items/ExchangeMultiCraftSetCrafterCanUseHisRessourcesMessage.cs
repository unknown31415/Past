using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage : NetworkMessage
	{
        public bool allow;
        public override uint Id
        {
        	get { return 6021; }
        }
        public ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage()
        {
        }
        public ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage(bool allow)
        {
            this.allow = allow;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(allow);
        }
        public override void Deserialize(IDataReader reader)
        {
            allow = reader.ReadBoolean();
		}
	}
}
