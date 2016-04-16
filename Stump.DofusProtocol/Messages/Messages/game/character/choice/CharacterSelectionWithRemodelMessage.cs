









// Generated on 07/24/2015 23:19:51
using System;
using System.Collections.Generic;
using System.Linq;
using Stump.DofusProtocol.Types;
using Stump.DofusProtocol.Messages;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    public class CharacterSelectionWithRemodelMessage : CharacterSelectionMessage
    {
        public const ushort Id = 6549;
        public override ushort MessageId
        {
            get { return Id; }
        }
        
        public Types.RemodelingInformation remodel;
        
        public CharacterSelectionWithRemodelMessage()
        {
        }
        
        public CharacterSelectionWithRemodelMessage(int id, Types.RemodelingInformation remodel)
         : base(id)
        {
            this.remodel = remodel;
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            remodel.Serialize(writer);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            remodel = new Types.RemodelingInformation();
            remodel.Deserialize(reader);
        }
        
    }
    
}