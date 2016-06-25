using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ObjectUseOnCellMessage : ObjectUseMessage
	{
        public short cells;
        public override uint Id
        {
        	get { return 3013; }
        }
        public ObjectUseOnCellMessage()
        {
        }
        public ObjectUseOnCellMessage(int objectUID, short cells) : base(objectUID)
        {
            this.cells = cells;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(cells);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            cells = reader.ReadShort();
            if (cells < 0 || cells > 559)
                throw new Exception("Forbidden value on cells = " + cells + ", it doesn't respect the following condition : cells < 0 || cells > 559");
		}
	}
}
