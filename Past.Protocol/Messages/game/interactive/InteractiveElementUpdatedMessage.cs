using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class InteractiveElementUpdatedMessage : NetworkMessage
	{
        public InteractiveElement interactiveElement;
        public override uint Id
        {
        	get { return 5708; }
        }
        public InteractiveElementUpdatedMessage()
        {
        }
        public InteractiveElementUpdatedMessage(InteractiveElement interactiveElement)
        {
            this.interactiveElement = interactiveElement;
        }
        public override void Serialize(IDataWriter writer)
        {
            interactiveElement.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            interactiveElement = new InteractiveElement();
            interactiveElement.Deserialize(reader);
		}
	}
}
