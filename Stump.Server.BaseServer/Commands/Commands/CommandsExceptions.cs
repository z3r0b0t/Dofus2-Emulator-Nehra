using Stump.DofusProtocol.Enums;
using System;
using System.Collections.Generic;
namespace Stump.Server.BaseServer.Commands.Commands
{
	public class CommandsExceptions : SubCommand
	{
		public CommandsExceptions()
		{
			base.Aliases = new string[]
			{
				"cmderror"
			};
			base.ParentCommand = typeof(DebugCommand);
			base.RequiredRole = RoleEnum.Administrator;
			base.Description = "Give command error details";
			base.AddParameter<int>("index", "i", "Error index (last if not defined)", 0, true, null);
		}
		public override void Execute(TriggerBase trigger)
		{
			int num;
			if (!trigger.IsArgumentDefined("index"))
			{
				num = trigger.User.CommandsErrors.Count - 1;
			}
			else
			{
				num = trigger.Get<int>("index");
			}
			if (trigger.User.CommandsErrors.Count <= num)
			{
				trigger.ReplyError("No error at index {0}", new object[]
				{
					num
				});
			}
			else
			{
				KeyValuePair<string, Exception> keyValuePair = trigger.User.CommandsErrors[num];
				trigger.Reply("Command : " + keyValuePair.Key);
				trigger.Reply("Exception : ");
				string[] array = keyValuePair.Value.ToString().Split(new char[]
				{
					'\r',
					'\n'
				}, StringSplitOptions.RemoveEmptyEntries);
				for (int i = 0; i < array.Length; i++)
				{
					string text = array[i];
					trigger.Reply(text);
				}
			}
		}
	}
}
