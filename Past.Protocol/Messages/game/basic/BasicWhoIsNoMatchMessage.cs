using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class BasicWhoIsNoMatchMessage : NetworkMessage
	{
        public string search;
        public override uint Id
        {
        	get { return 179; }
        }
        public BasicWhoIsNoMatchMessage()
        {
        }
        public BasicWhoIsNoMatchMessage(string search)
        {
            this.search = search;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(search);
        }
        public override void Deserialize(IDataReader reader)
        {
            search = reader.ReadUTF();
		}
	}
}
