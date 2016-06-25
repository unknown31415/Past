using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ChallengeTargetsListMessage : NetworkMessage
	{
        public int[] targetIds;
        public short[] targetCells;
        public override uint Id
        {
        	get { return 5613; }
        }
        public ChallengeTargetsListMessage()
        {
        }
        public ChallengeTargetsListMessage(int[] targetIds, short[] targetCells)
        {
            this.targetIds = targetIds;
            this.targetCells = targetCells;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)targetIds.Length);
            foreach (var entry in targetIds)
            {
                 writer.WriteInt(entry);
            }
            writer.WriteUShort((ushort)targetCells.Length);
            foreach (var entry in targetCells)
            {
                 writer.WriteShort(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            targetIds = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 targetIds[i] = reader.ReadInt();
            }
            limit = reader.ReadUShort();
            targetCells = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 targetCells[i] = reader.ReadShort();
            }
		}
	}
}
