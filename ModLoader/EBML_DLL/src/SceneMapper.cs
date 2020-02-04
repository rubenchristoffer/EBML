using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EBML {

    public class SceneMapper {

        /// <summary>
        /// Creates a scene tree of all the gameobjects that exists.
        /// </summary>
        /// <returns></returns>
        public static string GetAllGameObjectsInScene() {
            StringBuilder builder = new StringBuilder();

            foreach (GameObject root in SceneManager.GetActiveScene().GetRootGameObjects()) {
                AppendGameobjectsRecursively(root, builder, 0);
            }

            return builder.ToString();
        }

        private static void AppendGameobjectsRecursively (GameObject obj, StringBuilder builder, int level) {
            for (int i = 0; i < level; i++)
                builder.Append("\t");

            builder.AppendLine(obj.name);

            foreach (Transform child in obj.transform) {
                AppendGameobjectsRecursively(child.gameObject, builder, level + 1);
            }
        }

        public static string GetAllMonobehavioursInScene () {
            StringBuilder builder = new StringBuilder();

            foreach (MonoBehaviour behaviour in MonoBehaviour.FindObjectsOfType<MonoBehaviour>()) {
                builder.AppendLine(behaviour.ToString());
            }

            return builder.ToString();
        }

    }

}
