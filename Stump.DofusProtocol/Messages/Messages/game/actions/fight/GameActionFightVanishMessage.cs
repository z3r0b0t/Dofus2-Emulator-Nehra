









// Generated on 07/24/2015 23:19:49
using System;
using System.Collections.Generic;
using System.Linq;
using Stump.DofusProtocol.Types;
using Stump.DofusProtocol.Messages;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    public class GameActionFightVanishMessage : AbstractGameActionMessage
    {
        public const ushort Id = 6217;
        public override ushort MessageId
        {
            get { return Id; }
        }
        
        public int targetId;
        
        public GameActionFightVanishMessage()
        {
        }
        
        public GameActionFightVanishMessage(ushort actionId, int sourceId, int targetId)
         : base(actionId, sourceId)
        {
            this.targetId = targetId;
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteInt(targetId);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            targetId = reader.ReadInt();
        }
        
    }
    
}