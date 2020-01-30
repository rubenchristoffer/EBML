using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBML {

    public class ModInfo {

        public string name { get; private set; }
        public string description { get; private set; }
        public string version { get; private set; }

        public ModInfo (String name, String description, String version) {
            this.name = name;
            this.description = description;
            this.version = version;
        }

        public override string ToString() {
            return name + " - " + version;
        }

    }

}
