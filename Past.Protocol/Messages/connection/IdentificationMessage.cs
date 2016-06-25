using Past.Protocol.IO;
using Past.Protocol.Types;

namespace Past.Protocol.Messages
{
	public class IdentificationMessage : NetworkMessage
	{
        public Version version;
        public string login;
        public string password;
        public bool autoconnect;
        public override uint Id
        {
        	get { return 4; }
        }
        public IdentificationMessage()
        {
        }
        public IdentificationMessage(Version version, string login, string password, bool autoconnect)
        {
            this.version = version;
            this.login = login;
            this.password = password;
            this.autoconnect = autoconnect;
        }
        public override void Serialize(IDataWriter writer)
        {
            version.Serialize(writer);
            writer.WriteUTF(login);
            writer.WriteUTF(password);
            writer.WriteBoolean(autoconnect);
        }
        public override void Deserialize(IDataReader reader)
        {
            version = new Version();
            version.Deserialize(reader);
            login = reader.ReadUTF();
            password = reader.ReadUTF();
            autoconnect = reader.ReadBoolean();
		}
	}
}
