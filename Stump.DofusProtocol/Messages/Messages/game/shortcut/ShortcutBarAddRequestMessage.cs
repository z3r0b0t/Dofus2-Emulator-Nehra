









// Generated on 07/24/2015 23:20:16
using System;
using System.Collections.Generic;
using System.Linq;
using Stump.DofusProtocol.Types;
using Stump.DofusProtocol.Messages;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    public class ShortcutBarAddRequestMessage : Message
    {
        public const ushort Id = 6225;
        public override ushort MessageId
        {
            get { return Id; }
        }
        
        public sbyte barType;
        public Types.Shortcut shortcut;
        
        public ShortcutBarAddRequestMessage()
        {
        }
        
        public ShortcutBarAddRequestMessage(sbyte barType, Types.Shortcut shortcut)
        {
            this.barType = barType;
            this.shortcut = shortcut;
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteSByte(barType);
            writer.WriteShort(shortcut.TypeId);
            shortcut.Serialize(writer);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            barType = reader.ReadSByte();
            if (barType < 0)
                throw new Exception("Forbidden value on barType = " + barType + ", it doesn't respect the following condition : barType < 0");
            shortcut = Types.ProtocolTypeManager.GetInstance<Types.Shortcut>(reader.ReadShort());
            shortcut.Deserialize(reader);
        }
        
    }
    
}