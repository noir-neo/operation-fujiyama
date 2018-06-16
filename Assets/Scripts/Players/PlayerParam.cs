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
        private float _gravity;
        public float Gravity => _gravity;

        [SerializeField]
        private float _minAltitude;
        public float MinAltitude => _minAltitude;
    }
}
