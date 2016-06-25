using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeStartOkJobIndexMessage : NetworkMessage
	{
        public int[] jobs;
        public override uint Id
        {
        	get { return 5819; }
        }
        public ExchangeStartOkJobIndexMessage()
        {
        }
        public ExchangeStartOkJobIndexMessage(int[] jobs)
        {
            this.jobs = jobs;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)jobs.Length);
            foreach (var entry in jobs)
            {
                 writer.WriteInt(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            jobs = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 jobs[i] = reader.ReadInt();
            }
		}
	}
}
