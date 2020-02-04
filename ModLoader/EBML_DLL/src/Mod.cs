using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace EBML {

    public abstract class Mod {

        public abstract ModInfo modInfo { get; }

        public virtual void OnLoad() {}
        public virtual void OnInit() {}
        public virtual void OnPostInit() {}

        public virtual ModBehaviour[] GetModBehaviours() {
            return new ModBehaviour[0];
        }

    }

}
