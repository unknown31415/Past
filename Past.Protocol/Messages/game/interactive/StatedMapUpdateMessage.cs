using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class StatedMapUpdateMessage : NetworkMessage
	{
        public StatedElement[] statedElements;
        public override uint Id
        {
        	get { return 5716; }
        }
        public StatedMapUpdateMessage()
        {
        }
        public StatedMapUpdateMessage(StatedElement[] statedElements)
        {
            this.statedElements = statedElements;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)statedElements.Length);
            foreach (var entry in statedElements)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            statedElements = new StatedElement[limit];
            for (int i = 0; i < limit; i++)
            {
                 statedElements[i] = new StatedElement();
                 statedElements[i].Deserialize(reader);
            }
		}
	}
}
