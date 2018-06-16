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
            Store.Point = v;
            Store.IsHit = v.magnitude < _hittableDistance;

            SceneManager.LoadScene("Result");
        }
    }
}
