









// Generated on 07/24/2015 23:20:00
using System;
using System.Collections.Generic;
using System.Linq;
using Stump.DofusProtocol.Types;
using Stump.DofusProtocol.Messages;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    public class MapNpcsQuestStatusUpdateMessage : Message
    {
        public const ushort Id = 5642;
        public override ushort MessageId
        {
            get { return Id; }
        }
        
        public int mapId;
        public IEnumerable<int> npcsIdsWithQuest;
        public IEnumerable<Types.GameRolePlayNpcQuestFlag> questFlags;
        public IEnumerable<int> npcsIdsWithoutQuest;
        
        public MapNpcsQuestStatusUpdateMessage()
        {
        }
        
        public MapNpcsQuestStatusUpdateMessage(int mapId, IEnumerable<int> npcsIdsWithQuest, IEnumerable<Types.GameRolePlayNpcQuestFlag> questFlags, IEnumerable<int> npcsIdsWithoutQuest)
        {
            this.mapId = mapId;
            this.npcsIdsWithQuest = npcsIdsWithQuest;
            this.questFlags = questFlags;
            this.npcsIdsWithoutQuest = npcsIdsWithoutQuest;
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(mapId);
            writer.WriteUShort((ushort)npcsIdsWithQuest.Count());
            foreach (var entry in npcsIdsWithQuest)
            {
                 writer.WriteInt(entry);
            }
            writer.WriteUShort((ushort)questFlags.Count());
            foreach (var entry in questFlags)
            {
                 entry.Serialize(writer);
            }
            writer.WriteUShort((ushort)npcsIdsWithoutQuest.Count());
            foreach (var entry in npcsIdsWithoutQuest)
            {
                 writer.WriteInt(entry);
            }
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            mapId = reader.ReadInt();
            var limit = reader.ReadShort();
            npcsIdsWithQuest = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 (npcsIdsWithQuest as int[])[i] = reader.ReadInt();
            }
            limit = reader.ReadShort();
            questFlags = new Types.GameRolePlayNpcQuestFlag[limit];
            for (int i = 0; i < limit; i++)
            {
                 (questFlags as Types.GameRolePlayNpcQuestFlag[])[i] = new Types.GameRolePlayNpcQuestFlag();
                 (questFlags as Types.GameRolePlayNpcQuestFlag[])[i].Deserialize(reader);
            }
            limit = reader.ReadShort();
            npcsIdsWithoutQuest = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 (npcsIdsWithoutQuest as int[])[i] = reader.ReadInt();
            }
        }
        
    }
    
}