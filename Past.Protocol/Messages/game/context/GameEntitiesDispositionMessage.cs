using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameEntitiesDispositionMessage : NetworkMessage
	{
        public IdentifiedEntityDispositionInformations[] dispositions;
        public override uint Id
        {
        	get { return 5696; }
        }
        public GameEntitiesDispositionMessage()
        {
        }
        public GameEntitiesDispositionMessage(IdentifiedEntityDispositionInformations[] dispositions)
        {
            this.dispositions = dispositions;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)dispositions.Length);
            foreach (var entry in dispositions)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            dispositions = new IdentifiedEntityDispositionInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 dispositions[i] = new IdentifiedEntityDispositionInformations();
                 dispositions[i].Deserialize(reader);
            }
		}
	}
}
