using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class SetCharacterRestrictionsMessage : NetworkMessage
	{
        public ActorRestrictionsInformations restrictions;
        public override uint Id
        {
        	get { return 170; }
        }
        public SetCharacterRestrictionsMessage()
        {
        }
        public SetCharacterRestrictionsMessage(ActorRestrictionsInformations restrictions)
        {
            this.restrictions = restrictions;
        }
        public override void Serialize(IDataWriter writer)
        {
            restrictions.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            restrictions = new ActorRestrictionsInformations();
            restrictions.Deserialize(reader);
		}
	}
}
