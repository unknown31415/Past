using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PaddockPropertiesMessage : NetworkMessage
	{
        public PaddockInformations properties;
        public override uint Id
        {
        	get { return 5824; }
        }
        public PaddockPropertiesMessage()
        {
        }
        public PaddockPropertiesMessage(PaddockInformations properties)
        {
            this.properties = properties;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(properties.TypeId);
            properties.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            properties = (PaddockInformations)ProtocolTypeManager.GetInstance(reader.ReadUShort());
            properties.Deserialize(reader);
		}
	}
}
