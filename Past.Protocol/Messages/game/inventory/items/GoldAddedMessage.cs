using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GoldAddedMessage : NetworkMessage
	{
        public GoldItem gold;
        public override uint Id
        {
        	get { return 6030; }
        }
        public GoldAddedMessage()
        {
        }
        public GoldAddedMessage(GoldItem gold)
        {
            this.gold = gold;
        }
        public override void Serialize(IDataWriter writer)
        {
            gold.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            gold = new GoldItem();
            gold.Deserialize(reader);
		}
	}
}
