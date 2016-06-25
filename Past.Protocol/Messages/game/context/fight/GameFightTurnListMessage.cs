using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameFightTurnListMessage : NetworkMessage
	{
        public int[] ids;
        public int[] deadsIds;
        public override uint Id
        {
        	get { return 713; }
        }
        public GameFightTurnListMessage()
        {
        }
        public GameFightTurnListMessage(int[] ids, int[] deadsIds)
        {
            this.ids = ids;
            this.deadsIds = deadsIds;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)ids.Length);
            foreach (var entry in ids)
            {
                 writer.WriteInt(entry);
            }
            writer.WriteUShort((ushort)deadsIds.Length);
            foreach (var entry in deadsIds)
            {
                 writer.WriteInt(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            ids = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 ids[i] = reader.ReadInt();
            }
            limit = reader.ReadUShort();
            deadsIds = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 deadsIds[i] = reader.ReadInt();
            }
		}
	}
}
