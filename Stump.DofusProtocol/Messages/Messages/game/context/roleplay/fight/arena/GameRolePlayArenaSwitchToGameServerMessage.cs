









// Generated on 07/24/2015 23:19:58
using System;
using System.Collections.Generic;
using System.Linq;
using Stump.DofusProtocol.Types;
using Stump.DofusProtocol.Messages;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    public class GameRolePlayArenaSwitchToGameServerMessage : Message
    {
        public const ushort Id = 6574;
        public override ushort MessageId
        {
            get { return Id; }
        }
        
        
        public GameRolePlayArenaSwitchToGameServerMessage()
        {
        }
        
        
        public override void Serialize(ICustomDataOutput writer)
        {
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
        }
        
    }
    
}