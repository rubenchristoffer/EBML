using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBML {

    /// <summary>
    /// Contains various Singletons that is created by the
    /// developer of the game in order to find them easily
    /// </summary>
    public static class Singletons {

        /// <summary>
        /// 
        /// </summary>
        public static MapController MAP_CONTROLLER {
            get {
                return SingletonMonoBehaviour<MapController>.THIS;
            }
        }

        public static SaveController SAVE_CONTROLLER {
            get {
                return SingletonMonoBehaviour<SaveController>.THIS;
            }
        }

        public static TasksController TASKS_CONTROLLER {
            get {
                return SingletonMonoBehaviour<TasksController>.THIS;
            }
        }

        public static PropertyController PROPERTY_CONTROLLER {
            get {
                return SingletonMonoBehaviour<PropertyController>.THIS;
            }
        }

        public static WarController WAR_CONTROLLER {
            get {
                return SingletonMonoBehaviour<WarController>.THIS;
            }
        }

        public static DiplomacyController DIPLOMACY_CONTROLLER {
            get {
                return SingletonMonoBehaviour<DiplomacyController>.THIS;
            }
        }

        public static LocalizationController LOCALIZATION_CONTROLLER {
            get {
                return SingletonMonoBehaviour<LocalizationController>.THIS;
            }
        }

        public static ResourceController RESOURCE_CONTROLLER {
            get {
                return SingletonMonoBehaviour<ResourceController>.THIS;
            }
        }

        public static UserBank USER_BANK {
            get {
                return SingletonMonoBehaviour<UserBank>.THIS;
            }
        }

        public static NPCBankController NPC_BANK_CONTROLLER {
            get {
                return SingletonMonoBehaviour<NPCBankController>.THIS;
            }
        }

        public static IMFController IMF_CONTROLLER {
            get {
                return SingletonMonoBehaviour<IMFController>.THIS;
            }
        }

        public static BankLoger BANK_LOGER {
            get {
                return SingletonMonoBehaviour<BankLoger>.THIS;
            }
        }

        public static CamerasController CAMERAS_CONTROLLER {
            get {
                return SingletonMonoBehaviour<CamerasController>.THIS;
            }
        }

        public static MapEventController MAP_EVENT_CONTROLLER {
            get {
                return SingletonMonoBehaviour<MapEventController>.THIS;
            }
        }

        public static NationController NATION_CONTROLLER {
            get {
                return SingletonMonoBehaviour<NationController>.THIS;
            }
        }

        public static MercenariesController MERCENARIES_CONTROLLER {
            get {
                return SingletonMonoBehaviour<MercenariesController>.THIS;
            }
        }

        public static QualityController QUALITY_CONTROLLER {
            get {
                return SingletonMonoBehaviour<QualityController>.THIS;
            }
        }

        public static RevolutionController REVOLUTION_CONTROLLER {
            get {
                return SingletonMonoBehaviour<RevolutionController>.THIS;
            }
        }

        public static TavernController TAVERN_CONTROLLER {
            get {
                return SingletonMonoBehaviour<TavernController>.THIS;
            }
        }

        public static TaxController TAX_CONTROLLER {
            get {
                return SingletonMonoBehaviour<TaxController>.THIS;
            }
        }

        public static RecordController RECORD_CONTROLLER {
            get {
                return SingletonMonoBehaviour<RecordController>.THIS;
            }
        }

        public static DifficultyController DIFFICULTY_CONTROLLER {
            get {
                return SingletonMonoBehaviour<DifficultyController>.THIS;
            }
        }

        public static CreditsController CREDITS_CONTROLLER {
            get {
                return SingletonMonoBehaviour<CreditsController>.THIS;
            }
        }

        public static ChatController CHAT_CONTROLLER {
            get {
                return SingletonMonoBehaviour<ChatController>.THIS;
            }
        }

        public static HintsController HINTS_CONTROLLER {
            get {
                return SingletonMonoBehaviour<HintsController>.THIS;
            }
        }

        public static ManagerController MANAGER_CONTROLLER {
            get {
                return SingletonMonoBehaviour<ManagerController>.THIS;
            }
        }

        public static BotPanelCountriesController BOT_PANEL_COUNTRIES_CONTROLLER {
            get {
                return SingletonMonoBehaviour<BotPanelCountriesController>.THIS;
            }
        }

        public static RoundCalendarController ROUND_CALENDAR_CONTROLLER {
            get {
                return SingletonMonoBehaviour<RoundCalendarController>.THIS;
            }
        }

        public static ScienceTreeController SCIENCE_TREE_CONTROLLER {
            get {
                return SingletonMonoBehaviour<ScienceTreeController>.THIS;
            }
        }

        public static WaterCoastController WATER_COAST_CONTROLLER {
            get {
                return SingletonMonoBehaviour<WaterCoastController>.THIS;
            }
        }

        public static NPCCreditsController NPC_CREDITS_CONTROLLER {
            get {
                return SingletonMonoBehaviour<NPCCreditsController>.THIS;
            }
        }

        public static MainMenu MAIN_MENU {
            get {
                return SingletonMonoBehaviour<MainMenu>.THIS;
            }
        }

    }

}
