using Smod2.API;
using Smod2.Events;
using Smod2.EventHandlers;

namespace RussianRoulette
{
	class CommandEventHandler : IEventHandlerCallCommand
	{
		private readonly RussianRoulette plugin;

		public CommandEventHandler(RussianRoulette plugin) => this.plugin = plugin;

		public void OnCallCommand(PlayerCallCommandEvent ev)
		{
			string command = ev.Command.ToLower();
			if (!command.StartsWith("roulette")) return;

			// -- Prevent spectators from running the command
			if (ev.Player.TeamRole.Role == Role.SPECTATOR)
			{
				ev.ReturnMessage = "Spectators can't die, stupid.";
				return;
			}

			// -- Do the magic
			if (this.plugin.rnd.Next(0, 100) < this.plugin.GetConfigInt("roulette_chance"))
			{
				ev.Player.Kill(DamageType.WALL);
				ev.ReturnMessage = "Better luck next time, fuckboy.";
			}
			else
			{
				ev.ReturnMessage = "The gods smile upon you today.";
			}
		}
	}
}
