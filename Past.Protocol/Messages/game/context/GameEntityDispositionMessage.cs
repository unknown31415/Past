using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameEntityDispositionMessage : NetworkMessage
	{
        public IdentifiedEntityDispositionInformations disposition;
        public override uint Id
        {
        	get { return 5693; }
        }
        public GameEntityDispositionMessage()
        {
        }
        public GameEntityDispositionMessage(IdentifiedEntityDispositionInformations disposition)
        {
            this.disposition = disposition;
        }
        public override void Serialize(IDataWriter writer)
        {
            disposition.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            disposition = new IdentifiedEntityDispositionInformations();
            disposition.Deserialize(reader);
		}
	}
}
