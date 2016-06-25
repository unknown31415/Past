using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class MapInformationsRequestMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 225; }
        }
        public MapInformationsRequestMessage()
        {
        }
        public override void Serialize(IDataWriter writer)
        {
        }
        public override void Deserialize(IDataReader reader)
        {
		}
	}
}
