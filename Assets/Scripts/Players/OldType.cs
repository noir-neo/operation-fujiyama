using UniRx;
using UnityEngine;

namespace Players
{
    public class OldType : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera;
        [SerializeField]
        private PlayerCore _core;

        void Start()
        {
            _core.Altitude
                .Subscribe(ApplyCameraSize)
                .AddTo(this);
        }

        private void ApplyCameraSize(float size)
        {
            _camera.orthographicSize = size;
        }
    }
}
