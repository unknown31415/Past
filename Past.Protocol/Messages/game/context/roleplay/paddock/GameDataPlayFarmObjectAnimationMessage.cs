using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameDataPlayFarmObjectAnimationMessage : NetworkMessage
	{
        public short[] cellId;
        public override uint Id
        {
        	get { return 6026; }
        }
        public GameDataPlayFarmObjectAnimationMessage()
        {
        }
        public GameDataPlayFarmObjectAnimationMessage(short[] cellId)
        {
            this.cellId = cellId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)cellId.Length);
            foreach (var entry in cellId)
            {
                 writer.WriteShort(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            cellId = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 cellId[i] = reader.ReadShort();
            }
		}
	}
}
