









// Generated on 07/24/2015 23:19:52
using System;
using System.Collections.Generic;
using System.Linq;
using Stump.DofusProtocol.Types;
using Stump.DofusProtocol.Messages;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    public class ChatClientPrivateWithObjectMessage : ChatClientPrivateMessage
    {
        public const ushort Id = 852;
        public override ushort MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.ObjectItem> objects;
        
        public ChatClientPrivateWithObjectMessage()
        {
        }
        
        public ChatClientPrivateWithObjectMessage(string content, string receiver, IEnumerable<Types.ObjectItem> objects)
         : base(content, receiver)
        {
            this.objects = objects;
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteUShort((ushort)objects.Count());
            foreach (var entry in objects)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadShort();
            objects = new Types.ObjectItem[limit];
            for (int i = 0; i < limit; i++)
            {
                 (objects as Types.ObjectItem[])[i] = new Types.ObjectItem();
                 (objects as Types.ObjectItem[])[i].Deserialize(reader);
            }
        }
        
    }
    
}