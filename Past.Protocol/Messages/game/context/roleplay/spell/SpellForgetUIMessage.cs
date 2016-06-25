using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class SpellForgetUIMessage : NetworkMessage
	{
        public bool open;
        public override uint Id
        {
        	get { return 5565; }
        }
        public SpellForgetUIMessage()
        {
        }
        public SpellForgetUIMessage(bool open)
        {
            this.open = open;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(open);
        }
        public override void Deserialize(IDataReader reader)
        {
            open = reader.ReadBoolean();
		}
	}
}
