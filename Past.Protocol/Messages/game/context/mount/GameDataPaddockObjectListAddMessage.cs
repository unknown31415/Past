using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameDataPaddockObjectListAddMessage : NetworkMessage
	{
        public PaddockItem[] paddockItemDescription;
        public override uint Id
        {
        	get { return 5992; }
        }
        public GameDataPaddockObjectListAddMessage()
        {
        }
        public GameDataPaddockObjectListAddMessage(PaddockItem[] paddockItemDescription)
        {
            this.paddockItemDescription = paddockItemDescription;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)paddockItemDescription.Length);
            foreach (var entry in paddockItemDescription)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            paddockItemDescription = new PaddockItem[limit];
            for (int i = 0; i < limit; i++)
            {
                 paddockItemDescription[i] = new PaddockItem();
                 paddockItemDescription[i].Deserialize(reader);
            }
		}
	}
}
