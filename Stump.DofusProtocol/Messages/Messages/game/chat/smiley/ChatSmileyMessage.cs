









// Generated on 07/24/2015 23:19:53
using System;
using System.Collections.Generic;
using System.Linq;
using Stump.DofusProtocol.Types;
using Stump.DofusProtocol.Messages;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    public class ChatSmileyMessage : Message
    {
        public const ushort Id = 801;
        public override ushort MessageId
        {
            get { return Id; }
        }
        
        public int entityId;
        public sbyte smileyId;
        public int accountId;
        
        public ChatSmileyMessage()
        {
        }
        
        public ChatSmileyMessage(int entityId, sbyte smileyId, int accountId)
        {
            this.entityId = entityId;
            this.smileyId = smileyId;
            this.accountId = accountId;
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(entityId);
            writer.WriteSByte(smileyId);
            writer.WriteInt(accountId);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            entityId = reader.ReadInt();
            smileyId = reader.ReadSByte();
            if (smileyId < 0)
                throw new Exception("Forbidden value on smileyId = " + smileyId + ", it doesn't respect the following condition : smileyId < 0");
            accountId = reader.ReadInt();
            if (accountId < 0)
                throw new Exception("Forbidden value on accountId = " + accountId + ", it doesn't respect the following condition : accountId < 0");
        }
        
    }
    
}