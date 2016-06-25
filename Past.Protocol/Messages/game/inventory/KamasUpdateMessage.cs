using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class KamasUpdateMessage : NetworkMessage
	{
        public int kamasTotal;
        public override uint Id
        {
        	get { return 5537; }
        }
        public KamasUpdateMessage()
        {
        }
        public KamasUpdateMessage(int kamasTotal)
        {
            this.kamasTotal = kamasTotal;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(kamasTotal);
        }
        public override void Deserialize(IDataReader reader)
        {
            kamasTotal = reader.ReadInt();
		}
	}
}
