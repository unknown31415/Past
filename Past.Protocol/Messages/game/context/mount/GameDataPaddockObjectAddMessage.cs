using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameDataPaddockObjectAddMessage : NetworkMessage
	{
        public PaddockItem paddockItemDescription;
        public override uint Id
        {
        	get { return 5990; }
        }
        public GameDataPaddockObjectAddMessage()
        {
        }
        public GameDataPaddockObjectAddMessage(PaddockItem paddockItemDescription)
        {
            this.paddockItemDescription = paddockItemDescription;
        }
        public override void Serialize(IDataWriter writer)
        {
            paddockItemDescription.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            paddockItemDescription = new PaddockItem();
            paddockItemDescription.Deserialize(reader);
		}
	}
}
