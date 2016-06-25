using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class ObjectItemWithLookInRolePlay : ObjectItemInRolePlay
    {
        public EntityLook entityLook;
        public new const short Id = 197;
        public override short TypeId
        {
            get { return Id; }
        }
        public ObjectItemWithLookInRolePlay()
        {
        }
        public ObjectItemWithLookInRolePlay(short cellId, short objectGID, EntityLook entityLook) : base(cellId, objectGID)
        {
            this.entityLook = entityLook;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            entityLook.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            entityLook = new EntityLook();
            entityLook.Deserialize(reader);
        }
    }
}
