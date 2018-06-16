using System;
using UnityEngine;

namespace Players
{
    [Serializable]
    public class PlayerParam
    {
        [SerializeField]
        private float _moveSpeed;
        public float MoveSpeed => _moveSpeed;

        [SerializeField]
        private float _torque;
        public float Torque => _torque;
        [SerializeField]
        private float _torqueAcceleration;
        public float TorqueAcceleration => _torqueAcceleration;

        [SerializeField]
        private float _fallSpeed;
        public float FallSpeed => _fallSpeed;
        [SerializeField]
        private float _fallSpeedAcceleration;
        public float FallSpeedAcceleration => _fallSpeedAcceleration;

        [SerializeField]
        private float _minAltitude;
        public float MinAltitude => _minAltitude;
    }
}
