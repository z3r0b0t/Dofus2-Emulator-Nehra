using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;

namespace Stump.Server.WorldServer.Game.Conditions.Criterions
{
	public class QuestActiveCriterion : Criterion
	{
		public const string Identifier = "Qa";
		public int QuestId
		{
			get;
			set;
		}
		public override bool Eval(Character character)
		{
			return true;
		}
		public override void Build()
		{
			int questId;
			if (!int.TryParse(base.Literal, out questId))
			{
				throw new System.Exception(string.Format("Cannot build QuestActiveCriterion, {0} is not a valid quest id", base.Literal));
			}
			this.QuestId = questId;
		}
		public override string ToString()
		{
			return base.FormatToString("Qa");
		}
	}
}
