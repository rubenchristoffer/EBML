using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBML {

    /// <summary>
    /// This class should be used to
    /// contain metadata about a mod.
    /// </summary>
    public class ModInfo {

        /// <summary>
        /// This is the official name of the mod.
        /// </summary>
        public string name { get; private set; }

        /// <summary>
        /// This is a description of the mod.
        /// </summary>
        public string description { get; private set; }

        /// <summary>
        /// This is the current version of the mod.
        /// </summary>
        public string version { get; private set; }

        /// <summary>
        /// Creates a new ModInfo instance.
        /// </summary>
        /// <param name="name">The name of the mod</param>
        /// <param name="description">The description of the mod</param>
        /// <param name="version">The current version of the mod</param>
        public ModInfo (string name, string description, string version) {
            this.name = name;
            this.description = description;
            this.version = version;
        }

        /// <summary>
        /// Gets the string representation of ModInfo.
        /// </summary>
        /// <returns>String in form '[name] - [version]'</returns>
        public override string ToString() {
            return name + " - " + version;
        }

    }

}
