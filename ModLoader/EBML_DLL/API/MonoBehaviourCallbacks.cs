using UnityEngine;

#pragma warning disable IDE0051

namespace EBML.API {

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
        public delegate void VoidDelegate ();

        /// <summary>
        /// Event for subscribing to the Awake callback.
        /// </summary>
        public static event VoidDelegate AwakeEvent;

        /// <summary>
        /// Event for subscribing to the Start callback.
        /// </summary>
        public static event VoidDelegate StartEvent;

        /// <summary>
        /// Event for subscribing to the Update callback.
        /// </summary>
        public static event VoidDelegate UpdateEvent;

        /// <summary>
        /// Event for subscribing to the LateUpdate callback.
        /// </summary>
        public static event VoidDelegate LateUpdateEvent;

        /// <summary>
        /// Event for subscribing to the OnGUI callback.
        /// </summary>
        public static event VoidDelegate OnGUIEvent;

        /// <summary>
        /// Event for subscribing to the FixedUpdate callback.
        /// </summary>
        public static event VoidDelegate FixedUpdateEvent;

        void Awake () {
            if (AwakeEvent != null)
                AwakeEvent ();
        }

        void Start () {
            if (StartEvent != null)
                StartEvent ();
        }

        void Update () {
            if (UpdateEvent != null)
                UpdateEvent ();
        }

        void LateUpdate () {
            if (LateUpdateEvent != null)
                LateUpdateEvent ();
        }

        void OnGUI () {
            if (OnGUIEvent != null)
                OnGUIEvent ();
        }

        void FixedUpdate () {
            if (FixedUpdateEvent != null)
                FixedUpdateEvent ();
        }

    }

}

#pragma warning restore IDE0051