using System.Linq;
using UnityComponents;
using UnityComponents.Configurations.Enemy;
using UnityComponents.Configurations.Level;
using UnityComponents.Enemies;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Editor
{
    [CustomEditor(typeof(SpawnConfiguration))]
    public class SpawnEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            SpawnConfiguration spawnConfiguration = (SpawnConfiguration) target;

            if (GUILayout.Button("Collect"))
            {
                EnemySpawnPoint enemySpawnPoint = FindObjectsOfType<EnemySpawnPoint>()
                    .FirstOrDefault(x => x.id == spawnConfiguration.ID);

                spawnConfiguration.wayPoints = enemySpawnPoint.GetComponentInChildren<WayPoints>().wayPointsPosition
                    .Select(x => x.position).ToArray();

                spawnConfiguration.position = enemySpawnPoint.transform.position;
            }

            EditorUtility.SetDirty(target);
        }
    }
}