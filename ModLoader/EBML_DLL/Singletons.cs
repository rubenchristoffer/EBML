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
		public static Loader Loader {
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
		public static TurnManager TurnManager {
			get {
				return SingletonMonoBehaviour<TurnManager>.THIS;
			}
		}

		/// <summary>
		/// The MapController is responsible for the various regions
		/// and countries, along with generating the start map.
		/// </summary>
		public static MapController MapController {
			get {
				return SingletonMonoBehaviour<MapController>.THIS;
			}
		}

		/// <summary>
		/// The SaveController is responsible for saving game progress
		/// to disk.
		/// </summary>
		public static SaveController SaveController {
			get {
				return SingletonMonoBehaviour<SaveController>.THIS;
			}
		}

		/// <summary>
		/// The TasksController is responsible for handling various
		/// game tasks.
		/// </summary>
		public static TasksController TasksController {
			get {
				return SingletonMonoBehaviour<TasksController>.THIS;
			}
		}

		/// <summary>
		/// The PropertyController is responsible for handling
		/// the properties in the game.
		/// </summary>
		public static PropertyController PropertyController {
			get {
				return SingletonMonoBehaviour<PropertyController>.THIS;
			}
		}

		/// <summary>
		/// The WarController is responsible for handing wars
		/// in the game.
		/// </summary>
		public static WarController WarController {
			get {
				return SingletonMonoBehaviour<WarController>.THIS;
			}
		}

		/// <summary>
		/// The DiplomacyController is responsible for diplomacy
		/// in the game.
		/// </summary>
		public static DiplomacyController DiplomacyController {
			get {
				return SingletonMonoBehaviour<DiplomacyController>.THIS;
			}
		}

		/// <summary>
		/// The LocalizationController is responsible for getting the correct
		/// words based on which language profile is active.
		/// </summary>
		public static LocalizationController LocalizationController {
			get {
				return SingletonMonoBehaviour<LocalizationController>.THIS;
			}
		}

		/// <summary>
		/// The ResourceController is responsible for all resources in the game,
		/// including weapons.
		/// </summary>
		public static ResourceController ResourceController {
			get {
				return SingletonMonoBehaviour<ResourceController>.THIS;
			}
		}

		/// <summary>
		/// The UserBank is responsible for the actual player and contains
		/// data about the player.
		/// </summary>
		public static UserBank UserBank {
			get {
				return SingletonMonoBehaviour<UserBank>.THIS;
			}
		}

		/// <summary>
		/// The NPCBankController is responsible for the opponents in the game.
		/// </summary>
		public static NPCBankController NPCBankController {
			get {
				return SingletonMonoBehaviour<NPCBankController>.THIS;
			}
		}

		/// <summary>
		/// The IMFController is responsible for handling IMF
		/// (International Monetary Fund)
		/// </summary>
		public static IMFController IMFController {
			get {
				return SingletonMonoBehaviour<IMFController>.THIS;
			}
		}

		/// <summary>
		/// The CamerasController is responsible for game cameras.
		/// </summary>
		public static CamerasController CamerasController {
			get {
				return SingletonMonoBehaviour<CamerasController>.THIS;
			}
		}

		/// <summary>
		/// The MapEventController is responsible for various map events
		/// such as hunger, rebellion, industry booms etc.
		/// </summary>
		public static MapEventController MapEventController {
			get {
				return SingletonMonoBehaviour<MapEventController>.THIS;
			}
		}

		/// <summary>
		/// The NationController is responsible for the different
		/// nations in the game.
		/// </summary>
		public static NationController NationController {
			get {
				return SingletonMonoBehaviour<NationController>.THIS;
			}
		}

		/// <summary>
		/// The MercenariesController is responsible for Mercenary
		/// actions.
		/// </summary>
		public static MercenariesController MercenariesController {
			get {
				return SingletonMonoBehaviour<MercenariesController>.THIS;
			}
		}

		/// <summary>
		/// The QualityController is responsible for some of the
		/// graphics of the game.
		/// </summary>
		public static QualityController QualityController {
			get {
				return SingletonMonoBehaviour<QualityController>.THIS;
			}
		}

		/// <summary>
		/// The RevolutionController is responsible for handling
		/// revolutions in the game.
		/// </summary>
		public static RevolutionController RevolutionController {
			get {
				return SingletonMonoBehaviour<RevolutionController>.THIS;
			}
		}

		/// <summary>
		/// The TavernController is responsible for all the objects
		/// in the tavern.
		/// </summary>
		public static TavernController TavernController {
			get {
				return SingletonMonoBehaviour<TavernController>.THIS;
			}
		}

		/// <summary>
		/// The TaxController is responsible for calculating tax.
		/// </summary>
		public static TaxController TaxController {
			get {
				return SingletonMonoBehaviour<TaxController>.THIS;
			}
		}

		/// <summary>
		/// The RecordController is responsible for keeping the "records"
		/// of various fictional banks that you can see on the main menu.
		/// </summary>
		public static RecordController RecordController {
			get {
				return SingletonMonoBehaviour<RecordController>.THIS;
			}
		}

		/// <summary>
		/// The DifficultyController is responsible for game difficulty.
		/// </summary>
		public static DifficultyController DifficultyController {
			get {
				return SingletonMonoBehaviour<DifficultyController>.THIS;
			}
		}

		/// <summary>
		/// The CreditsController is responsible for the various credits
		/// you can issue to people. See NPC_CREDITS_CONTROLLER for credits
		/// regarding other banks.
		/// </summary>
		public static CreditsController CreditsController {
			get {
				return SingletonMonoBehaviour<CreditsController>.THIS;
			}
		}

		/// <summary>
		/// The HintsController is responsible for all the hints
		/// in the game.
		/// </summary>
		public static HintsController HintsController {
			get {
				return SingletonMonoBehaviour<HintsController>.THIS;
			}
		}

		/// <summary>
		/// The ManagerController is responsible for managers
		/// in the game (hiring, firing, searching for).
		/// </summary>
		public static ManagerController ManagerController {
			get {
				return SingletonMonoBehaviour<ManagerController>.THIS;
			}
		}

		/// <summary>
		/// The ScienceTreeController is responsible for the science tree.
		/// (researching sciences, progress, etc.)
		/// </summary>
		public static ScienceTreeController ScienceTreeController {
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
		public static NPCCreditsController NPCCreditsController {
			get {
				return SingletonMonoBehaviour<NPCCreditsController>.THIS;
			}
		}

		/// <summary>
		/// The MainMenu provides the various functions connected
		/// to the buttons on the main menu.
		/// </summary>
		public static MainMenu MainMenu {
			get {
				return SingletonMonoBehaviour<MainMenu>.THIS;
			}
		}

		/// <summary>
		/// The SteamAchievements handle Steam Achievements.
		/// NOTE! USE THIS WITH CAUTION!
		/// </summary>
		public static SteamAchievements SteamAchievements {
			get {
				return SingletonMonoBehaviour<SteamAchievements>.THIS;
			}
		}

	}

}
