using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Players;

namespace Maps {
    public class MapLodAdjuster : MonoBehaviour
    {
        [Serializable]
        public struct MapLod {
            [SerializeField]
            public GameObject sprite;
            [SerializeField]
            public float enableAltitude;
        }

        [SerializeField]
        private List<MapLod> _lods;

        [SerializeField]
        private PlayerCore _playerCore;

        private void Start()
        {
            _playerCore.Altitude
                .Subscribe(EnableSpritesIfNecessary)
                .AddTo(this);
        }

        private void EnableSpritesIfNecessary(float altitude)
        {
            foreach (var lod in _lods) {
                if (lod.enableAltitude >= altitude && !lod.sprite.activeSelf) {
                    lod.sprite.SetActive(true);
                }
            }
        }
    }
}
