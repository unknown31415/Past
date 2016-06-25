using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class InteractiveMapUpdateMessage : NetworkMessage
	{
        public InteractiveElement[] interactiveElements;
        public override uint Id
        {
        	get { return 5002; }
        }
        public InteractiveMapUpdateMessage()
        {
        }
        public InteractiveMapUpdateMessage(InteractiveElement[] interactiveElements)
        {
            this.interactiveElements = interactiveElements;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)interactiveElements.Length);
            foreach (var entry in interactiveElements)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            interactiveElements = new InteractiveElement[limit];
            for (int i = 0; i < limit; i++)
            {
                 interactiveElements[i] = new InteractiveElement();
                 interactiveElements[i].Deserialize(reader);
            }
		}
	}
}
