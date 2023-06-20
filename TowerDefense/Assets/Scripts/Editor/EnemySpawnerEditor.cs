using UnityComponents;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(EnemySpawnPoint))]
    public class EnemySpawnerEditor : UnityEditor.Editor
    {
        private const float RadiusSphere = 0.1f;

        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void DrawSpawnPoint(EnemySpawnPoint spawner, GizmoType gizmo)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(spawner.transform.position, RadiusSphere);
        }
    }
}