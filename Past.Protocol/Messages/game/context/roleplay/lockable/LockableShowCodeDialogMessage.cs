using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class LockableShowCodeDialogMessage : NetworkMessage
	{
        public bool changeOrUse;
        public sbyte codeSize;
        public override uint Id
        {
        	get { return 5740; }
        }
        public LockableShowCodeDialogMessage()
        {
        }
        public LockableShowCodeDialogMessage(bool changeOrUse, sbyte codeSize)
        {
            this.changeOrUse = changeOrUse;
            this.codeSize = codeSize;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(changeOrUse);
            writer.WriteSByte(codeSize);
        }
        public override void Deserialize(IDataReader reader)
        {
            changeOrUse = reader.ReadBoolean();
            codeSize = reader.ReadSByte();
            if (codeSize < 0)
                throw new Exception("Forbidden value on codeSize = " + codeSize + ", it doesn't respect the following condition : codeSize < 0");
		}
	}
}
