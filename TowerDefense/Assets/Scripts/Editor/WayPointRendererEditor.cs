using UnityComponents;
using UnityComponents.Configurations.Enemy;
using UnityComponents.Enemies;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(WayPoint))]
    public class WayPointRendererEditor : UnityEditor.Editor
    {
        private static readonly Color Color = new Color(1f, 0.55f, 0.84f);
        private const float RadiusSphere = 0.05f;

        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void DrawSpawnPoint(WayPoint spawner, GizmoType gizmo)
        {
            Gizmos.color = Color;
            Gizmos.DrawSphere(spawner.transform.position, RadiusSphere);
        }
    }
}