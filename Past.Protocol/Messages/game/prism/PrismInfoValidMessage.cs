using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PrismInfoValidMessage : NetworkMessage
	{
        public ProtectedEntityWaitingForHelpInfo waitingForHelpInfo;
        public override uint Id
        {
        	get { return 5858; }
        }
        public PrismInfoValidMessage()
        {
        }
        public PrismInfoValidMessage(ProtectedEntityWaitingForHelpInfo waitingForHelpInfo)
        {
            this.waitingForHelpInfo = waitingForHelpInfo;
        }
        public override void Serialize(IDataWriter writer)
        {
            waitingForHelpInfo.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            waitingForHelpInfo = new ProtectedEntityWaitingForHelpInfo();
            waitingForHelpInfo.Deserialize(reader);
		}
	}
}
