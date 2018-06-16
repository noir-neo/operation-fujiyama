using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Players
{
    public class InputEventProvider : MonoBehaviour
    {
        public IReadOnlyReactiveProperty<Vector2> Move => _move;
        private readonly ReactiveProperty<Vector2> _move = new ReactiveProperty<Vector2>();

        void Start()
        {
            this.UpdateAsObservable()
                .Select(_ => GetAxises().normalized)
                .Subscribe(x => _move.Value = x)
                .AddTo(this);
        }

        private Vector2 GetAxises()
        {
            return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
    }
}
