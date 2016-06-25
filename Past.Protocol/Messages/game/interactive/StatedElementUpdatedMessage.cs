using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class StatedElementUpdatedMessage : NetworkMessage
	{
        public StatedElement statedElement;
        public override uint Id
        {
        	get { return 5709; }
        }
        public StatedElementUpdatedMessage()
        {
        }
        public StatedElementUpdatedMessage(StatedElement statedElement)
        {
            this.statedElement = statedElement;
        }
        public override void Serialize(IDataWriter writer)
        {
            statedElement.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            statedElement = new StatedElement();
            statedElement.Deserialize(reader);
		}
	}
}
