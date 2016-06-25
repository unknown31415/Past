using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameContextRemoveMultipleElementsMessage : NetworkMessage
	{
        public int[] id;
        public override uint Id
        {
        	get { return 252; }
        }
        public GameContextRemoveMultipleElementsMessage()
        {
        }
        public GameContextRemoveMultipleElementsMessage(int[] id)
        {
            this.id = id;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)id.Length);
            foreach (var entry in id)
            {
                 writer.WriteInt(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            id = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 id[i] = reader.ReadInt();
            }
		}
	}
}
