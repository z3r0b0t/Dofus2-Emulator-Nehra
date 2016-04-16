









// Generated on 07/24/2015 23:19:56
using System;
using System.Collections.Generic;
using System.Linq;
using Stump.DofusProtocol.Types;
using Stump.DofusProtocol.Messages;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    public class MountRenamedMessage : Message
    {
        public const ushort Id = 5983;
        public override ushort MessageId
        {
            get { return Id; }
        }
        
        public int mountId;
        public string name;
        
        public MountRenamedMessage()
        {
        }
        
        public MountRenamedMessage(int mountId, string name)
        {
            this.mountId = mountId;
            this.name = name;
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(mountId);
            writer.WriteUTF(name);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            mountId = reader.ReadVarInt();
            name = reader.ReadUTF();
        }
        
    }
    
}