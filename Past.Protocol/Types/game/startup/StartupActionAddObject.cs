using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class StartupActionAddObject
    {
        public int uid;
        public string title;
        public string text;
        public string descUrl;
        public string pictureUrl;
        public ObjectItemMinimalInformation[] items;
        public const short Id = 52;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public StartupActionAddObject()
        {
        }
        public StartupActionAddObject(int uid, string title, string text, string descUrl, string pictureUrl, ObjectItemMinimalInformation[] items)
        {
            this.uid = uid;
            this.title = title;
            this.text = text;
            this.descUrl = descUrl;
            this.pictureUrl = pictureUrl;
            this.items = items;
        }
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(uid);
            writer.WriteUTF(title);
            writer.WriteUTF(text);
            writer.WriteUTF(descUrl);
            writer.WriteUTF(pictureUrl);
            writer.WriteUShort((ushort)items.Length);
            foreach (var entry in items)
            {
                entry.Serialize(writer);
            }
        }
        public virtual void Deserialize(IDataReader reader)
        {
            uid = reader.ReadInt();
            if (uid < 0)
                throw new Exception("Forbidden value on uid = " + uid + ", it doesn't respect the following condition : uid < 0");
            title = reader.ReadUTF();
            text = reader.ReadUTF();
            descUrl = reader.ReadUTF();
            pictureUrl = reader.ReadUTF();
            var limit = reader.ReadUShort();
            items = new Types.ObjectItemMinimalInformation[limit];
            for (int i = 0; i < limit; i++)
            {
                items[i] = new ObjectItemMinimalInformation();
                items[i].Deserialize(reader);
            }
        }
    }
}
