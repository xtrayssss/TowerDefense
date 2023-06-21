using System.Linq;
using Infrastructure.Services.AssetManagement;
using UnityComponents.Configurations.Enemy;
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

                levelConfiguration.enemySpawnerData = Resources
                    .LoadAll<SpawnerConfiguration>(AssetPaths.EnemySpawnerDataPath)
                    .Where(x => x.sceneName == GetActiveSceneName()).ToList();
            }

            EditorUtility.SetDirty(target);
        }

        private string GetActiveSceneName() =>
            SceneManager.GetActiveScene().name;
    }
}