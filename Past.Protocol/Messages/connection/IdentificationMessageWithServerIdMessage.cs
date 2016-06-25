using Past.Protocol.IO;
using Past.Protocol.Types;

namespace Past.Protocol.Messages
{
	public class IdentificationMessageWithServerIdMessage : IdentificationMessage
	{
        public short serverId;
        public override uint Id
        {
        	get { return 6104; }
        }
        public IdentificationMessageWithServerIdMessage()
        {
        }
        public IdentificationMessageWithServerIdMessage(Version version, string login, string password, bool autoconnect, short serverId) : base(version, login, password, autoconnect)
        {
            this.serverId = serverId;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(serverId);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            serverId = reader.ReadShort();
		}
	}
}
