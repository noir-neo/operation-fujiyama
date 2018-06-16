using UniRx;
using UnityEngine;

namespace Players
{
    public class PlayerCore : MonoBehaviour
    {
        [SerializeField]
        private PlayerParam _param;

        [SerializeField]
        private InputEventProvider _input;

        public IReadOnlyReactiveProperty<Vector2> Velocity => _velocity;
        private readonly ReactiveProperty<Vector2> _velocity = new ReactiveProperty<Vector2>();

        void Start()
        {
            _input.Move
                .Select(CalcVelocity)
                .Subscribe(v => _velocity.Value = v)
                .AddTo(this);
        }

        private Vector2 CalcVelocity(Vector2 v)
        {
            // TODO: 高度に応じて移動量変わる
            return v * _param.MoveSpeed;
        }
    }
}
