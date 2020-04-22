namespace EBML {

	/// <summary>
	/// Contains various Singletons that is created by the
	/// developer of the game.
	/// It is recommended to use the ModLoader API
	/// over these classes if you can.
	/// </summary>
	public static class Singletons {

		/// <summary>
		/// The Loader is responsible for loading
		/// the game scene and main menu.
		/// </summary>
		public static Loader LOADER {
			get {
				return SingletonMonoBehaviour<Loader>.THIS;
			}
		}

		/// <summary>
		/// The SoundManager is responsible for game sound.
		/// </summary>
		public static SoundManager SOUND_MANAGER {
			get {
				return SingletonMonoBehaviour<SoundManager>.THIS;
			}
		}

		/// <summary>
		/// The TurnManager is holds the current turn and is responsible
		/// for turn control.
		/// </summary>
		public static TurnManager TURN_MANAGER {
			get {
				return SingletonMonoBehaviour<TurnManager>.THIS;
			}
		}

		/// <summary>
		/// The MapController is responsible for the various regions
		/// and countries, along with generating the start map.
		/// </summary>
		public static MapController MAP_CONTROLLER {
			get {
				return SingletonMonoBehaviour<MapController>.THIS;
			}
		}

		/// <summary>
		/// The SaveController is responsible for saving game progress
		/// to disk.
		/// </summary>
		public static SaveController SAVE_CONTROLLER {
			get {
				return SingletonMonoBehaviour<SaveController>.THIS;
			}
		}

		/// <summary>
		/// The TasksController is responsible for handling various
		/// game tasks.
		/// </summary>
		public static TasksController TASKS_CONTROLLER {
			get {
				return SingletonMonoBehaviour<TasksController>.THIS;
			}
		}

		/// <summary>
		/// The PropertyController is responsible for handling
		/// the properties in the game.
		/// </summary>
		public static PropertyController PROPERTY_CONTROLLER {
			get {
				return SingletonMonoBehaviour<PropertyController>.THIS;
			}
		}

		/// <summary>
		/// The WarController is responsible for handing wars
		/// in the game.
		/// </summary>
		public static WarController WAR_CONTROLLER {
			get {
				return SingletonMonoBehaviour<WarController>.THIS;
			}
		}

		/// <summary>
		/// The DiplomacyController is responsible for diplomacy
		/// in the game.
		/// </summary>
		public static DiplomacyController DIPLOMACY_CONTROLLER {
			get {
				return SingletonMonoBehaviour<DiplomacyController>.THIS;
			}
		}

		/// <summary>
		/// The LocalizationController is responsible for getting the correct
		/// words based on which language profile is active.
		/// </summary>
		public static LocalizationController LOCALIZATION_CONTROLLER {
			get {
				return SingletonMonoBehaviour<LocalizationController>.THIS;
			}
		}

		/// <summary>
		/// The ResourceController is responsible for all resources in the game,
		/// including weapons.
		/// </summary>
		public static ResourceController RESOURCE_CONTROLLER {
			get {
				return SingletonMonoBehaviour<ResourceController>.THIS;
			}
		}

		/// <summary>
		/// The UserBank is responsible for the actual player and contains
		/// data about the player.
		/// </summary>
		public static UserBank USER_BANK {
			get {
				return SingletonMonoBehaviour<UserBank>.THIS;
			}
		}

		/// <summary>
		/// The NPCBankController is responsible for the opponents in the game.
		/// </summary>
		public static NPCBankController NPC_BANK_CONTROLLER {
			get {
				return SingletonMonoBehaviour<NPCBankController>.THIS;
			}
		}

		/// <summary>
		/// The IMFController is responsible for handling IMF
		/// (International Monetary Fund)
		/// </summary>
		public static IMFController IMF_CONTROLLER {
			get {
				return SingletonMonoBehaviour<IMFController>.THIS;
			}
		}

		/// <summary>
		/// The BankLoger is included in the game,
		/// but serves no function.
		/// </summary>
		[System.Obsolete]
		public static BankLoger BANK_LOGER {
			get {
				return SingletonMonoBehaviour<BankLoger>.THIS;
			}
		}

		/// <summary>
		/// The CamerasController is responsible for game cameras.
		/// </summary>
		public static CamerasController CAMERAS_CONTROLLER {
			get {
				return SingletonMonoBehaviour<CamerasController>.THIS;
			}
		}

		/// <summary>
		/// The MapEventController is responsible for various map events
		/// such as hunger, rebellion, industry booms etc.
		/// </summary>
		public static MapEventController MAP_EVENT_CONTROLLER {
			get {
				return SingletonMonoBehaviour<MapEventController>.THIS;
			}
		}

		/// <summary>
		/// The NationController is responsible for the different
		/// nations in the game.
		/// </summary>
		public static NationController NATION_CONTROLLER {
			get {
				return SingletonMonoBehaviour<NationController>.THIS;
			}
		}

		/// <summary>
		/// The MercenariesController is responsible for Mercenary
		/// actions.
		/// </summary>
		public static MercenariesController MERCENARIES_CONTROLLER {
			get {
				return SingletonMonoBehaviour<MercenariesController>.THIS;
			}
		}

		/// <summary>
		/// The QualityController is responsible for some of the
		/// graphics of the game.
		/// </summary>
		public static QualityController QUALITY_CONTROLLER {
			get {
				return SingletonMonoBehaviour<QualityController>.THIS;
			}
		}

		/// <summary>
		/// The RevolutionController is responsible for handling
		/// revolutions in the game.
		/// </summary>
		public static RevolutionController REVOLUTION_CONTROLLER {
			get {
				return SingletonMonoBehaviour<RevolutionController>.THIS;
			}
		}

		/// <summary>
		/// The TavernController is responsible for all the objects
		/// in the tavern.
		/// </summary>
		public static TavernController TAVERN_CONTROLLER {
			get {
				return SingletonMonoBehaviour<TavernController>.THIS;
			}
		}

		/// <summary>
		/// The TaxController is responsible for calculating tax.
		/// </summary>
		public static TaxController TAX_CONTROLLER {
			get {
				return SingletonMonoBehaviour<TaxController>.THIS;
			}
		}

		/// <summary>
		/// The RecordController is responsible for keeping the "records"
		/// of various fictional banks that you can see on the main menu.
		/// </summary>
		public static RecordController RECORD_CONTROLLER {
			get {
				return SingletonMonoBehaviour<RecordController>.THIS;
			}
		}

		/// <summary>
		/// The DifficultyController is responsible for game difficulty.
		/// </summary>
		public static DifficultyController DIFFICULTY_CONTROLLER {
			get {
				return SingletonMonoBehaviour<DifficultyController>.THIS;
			}
		}

		/// <summary>
		/// The CreditsController is responsible for the various credits
		/// you can issue to people. See NPC_CREDITS_CONTROLLER for credits
		/// regarding other banks.
		/// </summary>
		public static CreditsController CREDITS_CONTROLLER {
			get {
				return SingletonMonoBehaviour<CreditsController>.THIS;
			}
		}

		/// <summary>
		/// The HintsController is responsible for all the hints
		/// in the game.
		/// </summary>
		public static HintsController HINTS_CONTROLLER {
			get {
				return SingletonMonoBehaviour<HintsController>.THIS;
			}
		}

		/// <summary>
		/// The ManagerController is responsible for managers
		/// in the game (hiring, firing, searching for).
		/// </summary>
		public static ManagerController MANAGER_CONTROLLER {
			get {
				return SingletonMonoBehaviour<ManagerController>.THIS;
			}
		}

		/// <summary>
		/// The ScienceTreeController is responsible for the science tree.
		/// (researching sciences, progress, etc.)
		/// </summary>
		public static ScienceTreeController SCIENCE_TREE_CONTROLLER {
			get {
				return SingletonMonoBehaviour<ScienceTreeController>.THIS;
			}
		}

		/// <summary>
		/// The NPCCreditsController is responsible for handling NPC credits
		/// (genering offers, determining bankruptcy, etc.)
		/// See CREDITS_CONTROLLER for credits
		/// regarding people.
		/// </summary>
		public static NPCCreditsController NPC_CREDITS_CONTROLLER {
			get {
				return SingletonMonoBehaviour<NPCCreditsController>.THIS;
			}
		}

		/// <summary>
		/// The MainMenu provides the various functions connected
		/// to the buttons on the main menu.
		/// </summary>
		public static MainMenu MAIN_MENU {
			get {
				return SingletonMonoBehaviour<MainMenu>.THIS;
			}
		}

		/// <summary>
		/// The SteamAchievements handle Steam Achievements.
		/// NOTE! USE THIS WITH CAUTION!
		/// </summary>
		public static SteamAchievements STEAM_ACHIEVEMENTS {
			get {
				return SingletonMonoBehaviour<SteamAchievements>.THIS;
			}
		}

	}

}
