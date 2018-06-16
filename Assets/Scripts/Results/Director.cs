using UnityEngine;
using Players;

namespace Results
{
    public class Director : MonoBehaviour
    {
        [SerializeField]
        private GameObject _player;

        private void Awake()
        {
            Vector3 position = _player.transform.position;
            position.x = Store.Distance;
            _player.transform.position = position;
        }
    }
}
