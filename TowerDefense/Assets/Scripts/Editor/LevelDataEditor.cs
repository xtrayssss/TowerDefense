using System.Linq;
using UnityComponents;
using UnityComponents.Configurations.Level;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Editor
{
    [CustomEditor(typeof(LevelConfiguration))]
    public class LevelDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            LevelConfiguration levelConfiguration = (LevelConfiguration) target;

            if (GUILayout.Button("Collect"))
            {
                levelConfiguration.sceneName = GetActiveSceneName();
            }

            EditorUtility.SetDirty(target);
        }

        private string GetActiveSceneName() =>
            SceneManager.GetActiveScene().name;
    }
}