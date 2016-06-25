using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameContextRemoveElementMessage : NetworkMessage
	{
        public int id;
        public override uint Id
        {
        	get { return 251; }
        }
        public GameContextRemoveElementMessage()
        {
        }
        public GameContextRemoveElementMessage(int id)
        {
            this.id = id;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(id);
        }
        public override void Deserialize(IDataReader reader)
        {
            id = reader.ReadInt();
		}
	}
}
