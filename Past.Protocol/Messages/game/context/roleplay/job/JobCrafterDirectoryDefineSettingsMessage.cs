using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class JobCrafterDirectoryDefineSettingsMessage : NetworkMessage
	{
        public JobCrafterDirectorySettings settings;
        public override uint Id
        {
        	get { return 5649; }
        }
        public JobCrafterDirectoryDefineSettingsMessage()
        {
        }
        public JobCrafterDirectoryDefineSettingsMessage(JobCrafterDirectorySettings settings)
        {
            this.settings = settings;
        }
        public override void Serialize(IDataWriter writer)
        {
            settings.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            settings = new JobCrafterDirectorySettings();
            settings.Deserialize(reader);
		}
	}
}
