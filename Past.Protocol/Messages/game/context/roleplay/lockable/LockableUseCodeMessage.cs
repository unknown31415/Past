using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class LockableUseCodeMessage : NetworkMessage
	{
        public string code;
        public override uint Id
        {
        	get { return 5667; }
        }
        public LockableUseCodeMessage()
        {
        }
        public LockableUseCodeMessage(string code)
        {
            this.code = code;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(code);
        }
        public override void Deserialize(IDataReader reader)
        {
            code = reader.ReadUTF();
		}
	}
}
