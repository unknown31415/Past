using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class JobCrafterDirectorySettingsMessage : NetworkMessage
	{
        public JobCrafterDirectorySettings[] craftersSettings;
        public override uint Id
        {
        	get { return 5652; }
        }
        public JobCrafterDirectorySettingsMessage()
        {
        }
        public JobCrafterDirectorySettingsMessage(JobCrafterDirectorySettings[] craftersSettings)
        {
            this.craftersSettings = craftersSettings;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)craftersSettings.Length);
            foreach (var entry in craftersSettings)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            craftersSettings = new JobCrafterDirectorySettings[limit];
            for (int i = 0; i < limit; i++)
            {
                 craftersSettings[i] = new JobCrafterDirectorySettings();
                 craftersSettings[i].Deserialize(reader);
            }
		}
	}
}
