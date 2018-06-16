using System.Collections.Generic;
using UnityEngine;
using Players;

namespace Results
{
    public class Director : MonoBehaviour
    {
        [SerializeField]
        private GameObject _player;

        [SerializeField]
        private List<GameObject> _explosions;

        private void Awake()
        {
            Vector3 position = _player.transform.position;
            position.x = Store.Distance;
            _player.transform.position = position;

            foreach (var explosion in _explosions) {
                explosion.gameObject.SetActive(Store.IsHit);
            }
        }
    }
}
