using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class OrientedObjectItemWithLookInRolePlay : ObjectItemWithLookInRolePlay
    {
        public sbyte direction;
        public new const short Id = 199;
        public override short TypeId
        {
            get { return Id; }
        }
        public OrientedObjectItemWithLookInRolePlay()
        {
        }
        public OrientedObjectItemWithLookInRolePlay(short cellId, short objectGID, EntityLook entityLook, sbyte direction) : base(cellId, objectGID, entityLook)
        {
            this.direction = direction;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(direction);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            direction = reader.ReadSByte();
            if (direction < 0)
                throw new Exception("Forbidden value on direction = " + direction + ", it doesn't respect the following condition : direction < 0");
        }
    }
}
