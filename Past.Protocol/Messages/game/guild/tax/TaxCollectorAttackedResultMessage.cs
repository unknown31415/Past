using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class TaxCollectorAttackedResultMessage : NetworkMessage
	{
        public bool deadOrAlive;
        public TaxCollectorBasicInformations basicInfos;
        public override uint Id
        {
        	get { return 5635; }
        }
        public TaxCollectorAttackedResultMessage()
        {
        }
        public TaxCollectorAttackedResultMessage(bool deadOrAlive, TaxCollectorBasicInformations basicInfos)
        {
            this.deadOrAlive = deadOrAlive;
            this.basicInfos = basicInfos;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(deadOrAlive);
            basicInfos.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            deadOrAlive = reader.ReadBoolean();
            basicInfos = new TaxCollectorBasicInformations();
            basicInfos.Deserialize(reader);
		}
	}
}
