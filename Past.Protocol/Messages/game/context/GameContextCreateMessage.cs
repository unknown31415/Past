using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameContextCreateMessage : NetworkMessage
	{
        public sbyte context;
        public override uint Id
        {
        	get { return 200; }
        }
        public GameContextCreateMessage()
        {
        }
        public GameContextCreateMessage(sbyte context)
        {
            this.context = context;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(context);
        }
        public override void Deserialize(IDataReader reader)
        {
            context = reader.ReadSByte();
            if (context < 0)
                throw new Exception("Forbidden value on context = " + context + ", it doesn't respect the following condition : context < 0");
		}
	}
}
