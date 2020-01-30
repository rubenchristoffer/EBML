using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EBML.GUI {

    public class GUIBox : GUIObject {

        public Rect rect { get; private set; }
        public string text { get; private set; }

        public GUIBox (string name, Rect rect, String text) : base(name) {
            this.rect = rect;
            this.text = text;
        }

        public void SetText (string text) {
            this.text = text;
        }

        public void AppendText (string appendText) {
            SetText(text + appendText);
        }

        public void AppendLine (string appendText) {
            AppendText(appendText + "\n");
        }

        public override void Render() {
            UnityEngine.GUI.Box(rect, text);   
        }

    }

}
