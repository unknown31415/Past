using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class HousePropertiesMessage : NetworkMessage
	{
        public HouseInformations properties;
        public override uint Id
        {
        	get { return 5734; }
        }
        public HousePropertiesMessage()
        {
        }
        public HousePropertiesMessage(HouseInformations properties)
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
            properties = (HouseInformations)ProtocolTypeManager.GetInstance(reader.ReadUShort());
            properties.Deserialize(reader);
		}
	}
}
