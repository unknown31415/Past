using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class Version
    {
        public sbyte major;
        public sbyte minor;
        public sbyte revision;
        public sbyte buildType;
        public const short Id = 11;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public Version()
        {
        }
        public Version(sbyte major, sbyte minor, sbyte revision, sbyte buildType)
        {
            this.major = major;
            this.minor = minor;
            this.revision = revision;
            this.buildType = buildType;
        }
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(major);
            writer.WriteSByte(minor);
            writer.WriteSByte(revision);
            writer.WriteSByte(buildType);
        }
        public virtual void Deserialize(IDataReader reader)
        {
            major = reader.ReadSByte();
            if (major < 0)
                throw new Exception("Forbidden value on major = " + major + ", it doesn't respect the following condition : major < 0");
            minor = reader.ReadSByte();
            if (minor < 0)
                throw new Exception("Forbidden value on minor = " + minor + ", it doesn't respect the following condition : minor < 0");
            revision = reader.ReadSByte();
            if (revision < 0)
                throw new Exception("Forbidden value on revision = " + revision + ", it doesn't respect the following condition : revision < 0");
            buildType = reader.ReadSByte();
            if (buildType < 0)
                throw new Exception("Forbidden value on buildType = " + buildType + ", it doesn't respect the following condition : buildType < 0");
        }
    }
}