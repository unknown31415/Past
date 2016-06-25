using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildInformationsGeneralMessage : NetworkMessage
	{
        public bool enabled;
        public sbyte level;
        public double expLevelFloor;
        public double experience;
        public double expNextLevelFloor;
        public override uint Id
        {
        	get { return 5557; }
        }
        public GuildInformationsGeneralMessage()
        {
        }
        public GuildInformationsGeneralMessage(bool enabled, sbyte level, double expLevelFloor, double experience, double expNextLevelFloor)
        {
            this.enabled = enabled;
            this.level = level;
            this.expLevelFloor = expLevelFloor;
            this.experience = experience;
            this.expNextLevelFloor = expNextLevelFloor;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(enabled);
            writer.WriteSByte(level);
            writer.WriteDouble(expLevelFloor);
            writer.WriteDouble(experience);
            writer.WriteDouble(expNextLevelFloor);
        }
        public override void Deserialize(IDataReader reader)
        {
            enabled = reader.ReadBoolean();
            level = reader.ReadSByte();
            if (level < 0)
                throw new Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 0");
            expLevelFloor = reader.ReadDouble();
            if (expLevelFloor < 0)
                throw new Exception("Forbidden value on expLevelFloor = " + expLevelFloor + ", it doesn't respect the following condition : expLevelFloor < 0");
            experience = reader.ReadDouble();
            if (experience < 0)
                throw new Exception("Forbidden value on experience = " + experience + ", it doesn't respect the following condition : experience < 0");
            expNextLevelFloor = reader.ReadDouble();
            if (expNextLevelFloor < 0)
                throw new Exception("Forbidden value on expNextLevelFloor = " + expNextLevelFloor + ", it doesn't respect the following condition : expNextLevelFloor < 0");
		}
	}
}
