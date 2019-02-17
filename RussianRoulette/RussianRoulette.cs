using Smod2;
using Smod2.Attributes;
using Smod2.Config;
using System;

namespace RussianRoulette
{
	[PluginDetails(
		author = "Spooky",
		name = "RussianRoulette",
		description = "",
		id = "xyz.wizardlywonders.RussianRoulette",
		version = "1.0.0",
		SmodMajor = 3,
		SmodMinor = 2,
		SmodRevision = 2
	)]
	public class RussianRoulette : Plugin
	{
		internal Random rnd;

		public override void OnDisable()
		{
			this.Info("RussianRoulette has been disabled.");
		}

		public override void OnEnable()
		{
			this.Info("RussianRoulette has loaded successfully.");
		}

		public override void Register()
		{
			this.rnd = new Random();

			// Register config
			this.AddConfig(new ConfigSetting("roulette_chance", 20, SettingType.NUMERIC, true, "Percent chance (0-100) of dying when running the roulette command."));

			// Register events
			this.AddEventHandlers(new CommandEventHandler(this));
		}
	}
}
