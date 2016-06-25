using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeStartOkTaxCollectorMessage : NetworkMessage
	{
        public int collectorId;
        public ObjectItem[] objectsInfos;
        public int goldInfo;
        public override uint Id
        {
        	get { return 5780; }
        }
        public ExchangeStartOkTaxCollectorMessage()
        {
        }
        public ExchangeStartOkTaxCollectorMessage(int collectorId, ObjectItem[] objectsInfos, int goldInfo)
        {
            this.collectorId = collectorId;
            this.objectsInfos = objectsInfos;
            this.goldInfo = goldInfo;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(collectorId);
            writer.WriteUShort((ushort)objectsInfos.Length);
            foreach (var entry in objectsInfos)
            {
                 entry.Serialize(writer);
            }
            writer.WriteInt(goldInfo);
        }
        public override void Deserialize(IDataReader reader)
        {
            collectorId = reader.ReadInt();
            var limit = reader.ReadUShort();
            objectsInfos = new ObjectItem[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectsInfos[i] = new ObjectItem();
                 objectsInfos[i].Deserialize(reader);
            }
            goldInfo = reader.ReadInt();
            if (goldInfo < 0)
                throw new Exception("Forbidden value on goldInfo = " + goldInfo + ", it doesn't respect the following condition : goldInfo < 0");
		}
	}
}
