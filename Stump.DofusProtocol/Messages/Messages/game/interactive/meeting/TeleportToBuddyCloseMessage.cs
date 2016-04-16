









// Generated on 07/24/2015 23:20:08
using System;
using System.Collections.Generic;
using System.Linq;
using Stump.DofusProtocol.Types;
using Stump.DofusProtocol.Messages;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    public class TeleportToBuddyCloseMessage : Message
    {
        public const ushort Id = 6303;
        public override ushort MessageId
        {
            get { return Id; }
        }
        
        public ushort dungeonId;
        public uint buddyId;
        
        public TeleportToBuddyCloseMessage()
        {
        }
        
        public TeleportToBuddyCloseMessage(ushort dungeonId, uint buddyId)
        {
            this.dungeonId = dungeonId;
            this.buddyId = buddyId;
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarUhShort(dungeonId);
            writer.WriteVarUhInt(buddyId);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            dungeonId = reader.ReadVarUhShort();
            if (dungeonId < 0)
                throw new Exception("Forbidden value on dungeonId = " + dungeonId + ", it doesn't respect the following condition : dungeonId < 0");
            buddyId = reader.ReadVarUhInt();
            if (buddyId < 0)
                throw new Exception("Forbidden value on buddyId = " + buddyId + ", it doesn't respect the following condition : buddyId < 0");
        }
        
    }
    
}