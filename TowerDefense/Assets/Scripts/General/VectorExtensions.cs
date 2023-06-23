using System;
using UnityEngine;

namespace General
{
    public static class VectorExtensions
    {
        public static Vector3 GetAbsVector(this Vector3 source) =>
            new Vector3(Math.Abs(source.x), Math.Abs(source.y), Math.Abs(source.z));

        public static Vector2 GetAbsVector(this Vector2 source) =>
            new Vector2(Math.Abs(source.x), Math.Abs(source.y));
    }
}