using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeStartOkMountWithOutPaddockMessage : NetworkMessage
	{
        public MountClientData[] stabledMountsDescription;
        public override uint Id
        {
        	get { return 5991; }
        }
        public ExchangeStartOkMountWithOutPaddockMessage()
        {
        }
        public ExchangeStartOkMountWithOutPaddockMessage(MountClientData[] stabledMountsDescription)
        {
            this.stabledMountsDescription = stabledMountsDescription;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)stabledMountsDescription.Length);
            foreach (var entry in stabledMountsDescription)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            stabledMountsDescription = new MountClientData[limit];
            for (int i = 0; i < limit; i++)
            {
                 stabledMountsDescription[i] = new MountClientData();
                 stabledMountsDescription[i].Deserialize(reader);
            }
		}
	}
}
