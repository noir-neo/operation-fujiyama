using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace UIs
{
    public class KaijuMarker : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;

        void Start()
        {
            this.LateUpdateAsObservable()
                .Select(_ => RectTransformUtility.WorldToScreenPoint(Camera.main, Vector3.zero))
                .Subscribe(x => _rectTransform.position = x)
                .AddTo(this);
        }
    }
}
