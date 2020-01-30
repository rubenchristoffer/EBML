using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EBML {

    public static class EBMLInfo {

        public static string GAME_PATH = new DirectoryInfo(@".\").FullName;
        public static string EBML_PATH = GAME_PATH + @"EBML\";
        public static string LOG_PATH = EBML_PATH + @"Logs\";
        public static string MODS_PATH = EBML_PATH + @"Mods\";

    }

}
