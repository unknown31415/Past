using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class AtlasPointInformationsMessage : NetworkMessage
	{
        public AtlasPointsInformations type;
        public override uint Id
        {
        	get { return 5956; }
        }
        public AtlasPointInformationsMessage()
        {
        }
        public AtlasPointInformationsMessage(AtlasPointsInformations type)
        {
            this.type = type;
        }
        public override void Serialize(IDataWriter writer)
        {
            type.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            type = new AtlasPointsInformations();
            type.Deserialize(reader);
		}
	}
}
