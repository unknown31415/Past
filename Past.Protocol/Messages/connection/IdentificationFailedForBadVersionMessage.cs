using Past.Protocol.IO;
using Past.Protocol.Types;

namespace Past.Protocol.Messages
{
    public class IdentificationFailedForBadVersionMessage : IdentificationFailedMessage
	{
        public Version requiredVersion;
        public override uint Id
        {
        	get { return 21; }
        }
        public IdentificationFailedForBadVersionMessage()
        {
        }
        public IdentificationFailedForBadVersionMessage(sbyte reason, Version requiredVersion) : base(reason)
        {
            this.requiredVersion = requiredVersion;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            requiredVersion.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            requiredVersion = new Version();
            requiredVersion.Deserialize(reader);
		}
	}
}
