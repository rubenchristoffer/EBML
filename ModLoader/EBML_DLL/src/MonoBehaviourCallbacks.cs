using UnityEngine;

namespace EBML {

    public class MonoBehaviourCallbacks : MonoBehaviour {

        public delegate void VoidDelegate();

        public static event VoidDelegate awake;
        public static event VoidDelegate update;
        public static event VoidDelegate lateUpdate;
        public static event VoidDelegate onGUI;

        void Awake () {
            if (awake != null)
                awake();
        }

        void Update () {
            if (update != null)
                update();
        }

        void LateUpdate () {
            if (lateUpdate != null)
                lateUpdate();
        }

        void OnGUI () {
            if (onGUI != null)
                onGUI();
        }

    }

}
