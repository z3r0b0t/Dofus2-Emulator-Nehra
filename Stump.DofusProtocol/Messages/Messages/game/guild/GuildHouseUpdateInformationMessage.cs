









// Generated on 07/24/2015 23:20:06
using System;
using System.Collections.Generic;
using System.Linq;
using Stump.DofusProtocol.Types;
using Stump.DofusProtocol.Messages;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    public class GuildHouseUpdateInformationMessage : Message
    {
        public const ushort Id = 6181;
        public override ushort MessageId
        {
            get { return Id; }
        }
        
        public Types.HouseInformationsForGuild housesInformations;
        
        public GuildHouseUpdateInformationMessage()
        {
        }
        
        public GuildHouseUpdateInformationMessage(Types.HouseInformationsForGuild housesInformations)
        {
            this.housesInformations = housesInformations;
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            housesInformations.Serialize(writer);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            housesInformations = new Types.HouseInformationsForGuild();
            housesInformations.Deserialize(reader);
        }
        
    }
    
}