









// Generated on 07/24/2015 23:19:53
using System;
using System.Collections.Generic;
using System.Linq;
using Stump.DofusProtocol.Types;
using Stump.DofusProtocol.Messages;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    public class GameContextKickMessage : Message
    {
        public const ushort Id = 6081;
        public override ushort MessageId
        {
            get { return Id; }
        }
        
        public int targetId;
        
        public GameContextKickMessage()
        {
        }
        
        public GameContextKickMessage(int targetId)
        {
            this.targetId = targetId;
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(targetId);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            targetId = reader.ReadInt();
        }
        
    }
    
}