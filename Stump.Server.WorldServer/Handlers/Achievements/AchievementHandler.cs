﻿using Stump.Core.Reflection;
using Stump.DofusProtocol.Messages;
using Stump.DofusProtocol.Types;
using Stump.Server.BaseServer.Network;
using Stump.Server.WorldServer.Core.Network;
using Stump.Server.WorldServer.Database.Achievements;
using Stump.Server.WorldServer.Game.Achievements;
using Stump.Server.WorldServer.Handlers.Characters;
using System;
using System.Collections.Generic;

namespace Stump.Server.WorldServer.Handlers.Achievements
{
    public class AchievementHandler : WorldHandlerContainer
    {
        private AchievementHandler() { }

        [WorldHandler(AchievementDetailedListRequestMessage.Id)]
        public static void HandleAchievementDetailedListRequestMessage(WorldClient client, AchievementDetailedListRequestMessage message)
        {
            var category = Singleton<AchievementManager>.Instance.TryGetAchievementCategory(message.categoryId);
            if (category != null)
            {
                AchievementHandler.SendAchievementDetailedListMessage(client, new Achievement[0], client.Character.Achievement.TryGetFinishedAchievements(category));
            }
        }
        [WorldHandler(AchievementDetailsRequestMessage.Id)]
        public static void HandleAchievementDetailsRequestMessage(WorldClient client, AchievementDetailsRequestMessage message)
        {
            var template = Singleton<AchievementManager>.Instance.TryGetAchievement((uint)message.achievementId);
            if (template != null)
            {
                AchievementHandler.SendAchievementDetailsMessage(client, template.GetAchievement(client.Character.Achievement));
            }
        }
        [WorldHandler(AchievementRewardRequestMessage.Id)]
        public static void HandleAchievementRewardRequestMessage(WorldClient client, AchievementRewardRequestMessage message)
        {
            if (message.achievementId > 0)
            {
                var achievement = client.Character.Achievement.TryGetFinishedAchievement(message.achievementId);
                if (achievement != null)
                {
                    int experience;
                    int guildExperience;
                    if (client.Character.Achievement.RewardAchievement(achievement, out experience, out guildExperience))
                    {
                        AchievementHandler.SendAchievementRewardSuccessMessage(client, (short)message.achievementId);

                        if (experience > 0) { client.Character.AddExperience(experience); }
                        else { experience = 0; }

                        if (client.Character.GuildMember != null && guildExperience > 0) { client.Character.GuildMember.AddXP(guildExperience); }
                        else { guildExperience = 0; }

                        CharacterHandler.SendCharacterExperienceGainMessage(client, (ulong)experience, 0L, (ulong)guildExperience, 0L);
                    }
                    else
                    {
                        AchievementHandler.SendAchievementRewardErrorMessage(client, (short)message.achievementId);
                    }
                }
                else
                {
                    AchievementHandler.SendAchievementRewardErrorMessage(client, (short)message.achievementId);
                }
            }
        }
        [WorldHandler(StartupActionsAllAttributionMessage.Id)]
        public static void HandleStartupActionsAllAttributionMessage(WorldClient client, StartupActionsAllAttributionMessage message)
        {
            if (client.LastMessage is AchievementRewardRequestMessage)
            {
                client.Character.Achievement.RewardAllAchievements(new Action<AchievementTemplate, bool>((achievement, success) =>
                {
                    if (success)
                    {
                        AchievementHandler.SendAchievementRewardSuccessMessage(client, (short)achievement.Id);
                    }
                    else
                    {
                        AchievementHandler.SendAchievementRewardErrorMessage(client, (short)achievement.Id);
                    }
                }));
            }
        }

        public static void SendAchievementListMessage(IPacketReceiver client, IEnumerable<ushort> finishedAchievementsIds, IEnumerable<AchievementRewardable> rewardableAchievements)
        {
            client.Send(new AchievementListMessage(finishedAchievementsIds, rewardableAchievements));
        }
        public static void SendAchievementDetailedListMessage(IPacketReceiver client, IEnumerable<Achievement> startedAchievements, IEnumerable<Achievement> finishedAchievements)
        {
            client.Send(new AchievementDetailedListMessage(startedAchievements, finishedAchievements));
        }
        public static void SendAchievementDetailsMessage(IPacketReceiver client, Achievement achievement)
        {
            client.Send(new AchievementDetailsMessage(achievement));
        }
        public static void SendAchievementFinishedMessage(IPacketReceiver client, ushort id, byte finishedLevel)
        {
            client.Send(new AchievementFinishedMessage(id, finishedLevel));
        }
        public static void SendAchievementRewardSuccessMessage(IPacketReceiver client, short achievementId)
        {
            client.Send(new AchievementRewardSuccessMessage(achievementId));
        }
        public static void SendAchievementRewardErrorMessage(IPacketReceiver client, short achievementId)
        {
            client.Send(new AchievementRewardErrorMessage(achievementId));
        }
    }
}
