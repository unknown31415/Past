using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class GuildEmblem
    {
        public short symbolShape;
        public int symbolColor;
        public short backgroundShape;
        public int backgroundColor;
        public const short Id = 87;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public GuildEmblem()
        {
        }
        public GuildEmblem(short symbolShape, int symbolColor, short backgroundShape, int backgroundColor)
        {
            this.symbolShape = symbolShape;
            this.symbolColor = symbolColor;
            this.backgroundShape = backgroundShape;
            this.backgroundColor = backgroundColor;
        }
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteShort(symbolShape);
            writer.WriteInt(symbolColor);
            writer.WriteShort(backgroundShape);
            writer.WriteInt(backgroundColor);
        }
        public virtual void Deserialize(IDataReader reader)
        {
            symbolShape = reader.ReadShort();
            symbolColor = reader.ReadInt();
            backgroundShape = reader.ReadShort();
            backgroundColor = reader.ReadInt();
        }
    }
}