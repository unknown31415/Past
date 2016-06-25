using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ProtocolRequired : NetworkMessage
	{
        public int requiredVersion;
        public int currentVersion;
        public override uint Id
        {
        	get { return 1; }
        }
        public ProtocolRequired()
        {
        }
        public ProtocolRequired(int requiredVersion, int currentVersion)
        {
            this.requiredVersion = requiredVersion;
            this.currentVersion = currentVersion;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(requiredVersion);
            writer.WriteInt(currentVersion);
        }
        public override void Deserialize(IDataReader reader)
        {
            requiredVersion = reader.ReadInt();
            if (requiredVersion < 0)
                throw new Exception("Forbidden value on requiredVersion = " + requiredVersion + ", it doesn't respect the following condition : requiredVersion < 0");
            currentVersion = reader.ReadInt();
            if (currentVersion < 0)
                throw new Exception("Forbidden value on currentVersion = " + currentVersion + ", it doesn't respect the following condition : currentVersion < 0");
		}
	}
}
