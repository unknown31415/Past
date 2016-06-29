using Past.Protocol.IO;

namespace Past.Protocol.Messages
{
    public class DebugHighlightCellsMessage : NetworkMessage
	{
        public int color;
        public short[] cells;
        public override uint Id
        {
        	get { return 2001; }
        }
        public DebugHighlightCellsMessage()
        {
        }
        public DebugHighlightCellsMessage(int color, short[] cells)
        {
            this.color = color;
            this.cells = cells;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(color);
            writer.WriteUShort((ushort)cells.Length);
            foreach (var entry in cells)
            {
                 writer.WriteShort(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            color = reader.ReadInt();
            var limit = reader.ReadUShort();
            cells = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 cells[i] = reader.ReadShort();
            }
		}
	}
}
