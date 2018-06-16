using Players;
using UniRx;
using UnityEngine;

namespace UIs
{
    public class Title : MonoBehaviour
    {
        [SerializeField]
        private PlayerCore _playerCore;

        void Start()
        {
            _playerCore.Inject()
                .Subscribe(_ => gameObject.SetActive(false))
                .AddTo(this);
        }
    }
}
