using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBML.GUI {

    public abstract class GUIObject {

        public string name { get; private set; }

        public GUIObject (string name) {
            this.name = name;
        }

        public abstract void Render();

    }

}
