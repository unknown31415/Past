using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeStartOkMountMessage : ExchangeStartOkMountWithOutPaddockMessage
	{
        public MountClientData[] paddockedMountsDescription;
        public override uint Id
        {
        	get { return 5979; }
        }
        public ExchangeStartOkMountMessage()
        {
        }
        public ExchangeStartOkMountMessage(MountClientData[] stabledMountsDescription, MountClientData[] paddockedMountsDescription) : base(stabledMountsDescription)
        {
            this.paddockedMountsDescription = paddockedMountsDescription;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort((ushort)paddockedMountsDescription.Length);
            foreach (var entry in paddockedMountsDescription)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadUShort();
            paddockedMountsDescription = new MountClientData[limit];
            for (int i = 0; i < limit; i++)
            {
                 paddockedMountsDescription[i] = new MountClientData();
                 paddockedMountsDescription[i].Deserialize(reader);
            }
		}
	}
}
