using Past.Protocol.IO;

namespace Past.Protocol
{
    public abstract class NetworkMessage
    {
        byte BIT_RIGHT_SHIFT_LEN_PACKET_ID = 2;
        byte BIT_MASK = 3;

        public abstract uint Id { get; }
        public abstract void Serialize(IDataWriter writer);
        public abstract void Deserialize(IDataReader reader);

        public void Pack(BigEndianWriter writer)
        {
            Serialize(writer);
            WritePacket(writer);
        }

        public void UnPack(BigEndianReader reader)
        {
            Deserialize(reader);
        }

        public void WritePacket(IDataWriter output)
        {
            byte[] data = output.Data;
            output.Clear();
            var typeLen = ComputeTypeLen((uint)data.Length);
            output.WriteShort((short)SubComputeStaticHeader(Id, typeLen));
            switch (typeLen)
            {
                case 0:
                    return;
                case 1:
                    output.WriteByte((byte)data.Length);
                    break;
                case 2:
                    output.WriteShort((short)data.Length);
                    break;
                case 3:
                    output.WriteByte((byte)(data.Length >> 16 & 255));
                    output.WriteShort((short)(data.Length & 65535));
                    break;
            }
            output.WriteBytes(data);
        }

        public uint ComputeTypeLen(uint len)
        {
            if (len > 65535)
            {
                return 3;
            }
            if (len > 255)
            {
                return 2;
            }
            if (len > 0)
            {
                return 1;
            }
            return 0;
        }

        public uint SubComputeStaticHeader(uint msgId, uint typeLen)
        {
            return msgId << BIT_RIGHT_SHIFT_LEN_PACKET_ID | typeLen;
        }

        public override string ToString()
        {
            return base.GetType().Name;
        }
    }
}
