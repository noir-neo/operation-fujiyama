using Players;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Results {
    public class ResultLoader : MonoBehaviour
    {
        [SerializeField] private PlayerCore _playerCore;
        [SerializeField] private float _hittableDistance;

        void Start()
        {
            _playerCore.Impact()
                .Subscribe(StoreAndLoadResult)
                .AddTo(this);
        }

        private void StoreAndLoadResult(Vector2 v)
        {
            var distance = v.magnitude;
            Store.Distance = v.y;
            Store.IsHit = distance < _hittableDistance;

            SceneManager.LoadScene("Result");
        }
    }
}
