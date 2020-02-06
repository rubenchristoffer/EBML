using UnityEngine;

namespace EBML {

    /// <summary>
    /// This class is used to "hook" Unity's MonoBehaviour
    /// callback methods. You could also create your own MonoBehaviour
    /// and add it to a gameObject and it would have the same effect.
    /// However, using this class could be easier and better for performance.
    /// </summary>
    public class MonoBehaviourCallbacks : MonoBehaviour {

        /// <summary>
        /// Delegate for void functions with no parameters.
        /// </summary>
        public delegate void VoidDelegate();

        /// <summary>
        /// Event for subscribing to the Awake callback.
        /// </summary>
        public static event VoidDelegate awake;

        /// <summary>
        /// Event for subscribing to the Start callback.
        /// </summary>
        public static event VoidDelegate start;

        /// <summary>
        /// Event for subscribing to the Update callback.
        /// </summary>
        public static event VoidDelegate update;

        /// <summary>
        /// Event for subscribing to the LateUpdate callback.
        /// </summary>
        public static event VoidDelegate lateUpdate;

        /// <summary>
        /// Event for subscribing to the OnGUI callback.
        /// </summary>
        public static event VoidDelegate onGUI;

        /// <summary>
        /// Event for subscribing to the FixedUpdate callback.
        /// </summary>
        public static event VoidDelegate fixedUpdate;

        void Awake () {
            if (awake != null)
                awake();
        }

        void Start() {
            if (start != null)
                start();
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

        void FixedUpdate () {
            if (fixedUpdate != null)
                fixedUpdate();
        }

    }

}
