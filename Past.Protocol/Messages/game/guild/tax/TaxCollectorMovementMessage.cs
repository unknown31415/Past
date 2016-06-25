using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class TaxCollectorMovementMessage : NetworkMessage
	{
        public bool hireOrFire;
        public TaxCollectorBasicInformations basicInfos;
        public string playerName;
        public override uint Id
        {
        	get { return 5633; }
        }
        public TaxCollectorMovementMessage()
        {
        }
        public TaxCollectorMovementMessage(bool hireOrFire, TaxCollectorBasicInformations basicInfos, string playerName)
        {
            this.hireOrFire = hireOrFire;
            this.basicInfos = basicInfos;
            this.playerName = playerName;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(hireOrFire);
            basicInfos.Serialize(writer);
            writer.WriteUTF(playerName);
        }
        public override void Deserialize(IDataReader reader)
        {
            hireOrFire = reader.ReadBoolean();
            basicInfos = new TaxCollectorBasicInformations();
            basicInfos.Deserialize(reader);
            playerName = reader.ReadUTF();
		}
	}
}
