using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Players
{
    public class PlayerCore : MonoBehaviour
    {
        [SerializeField]
        private PlayerParam _param;

        [SerializeField]
        private InputEventProvider _input;

        private static readonly float StartAltitude = 5f;

        public IReadOnlyReactiveProperty<Vector2> Velocity => _velocity;
        private readonly ReactiveProperty<Vector2> _velocity = new ReactiveProperty<Vector2>();

        private readonly ReactiveProperty<float> _fallSpeed = new ReactiveProperty<float>();

        public IReadOnlyReactiveProperty<float> Altitude => _altitude;
        private readonly ReactiveProperty<float> _altitude = new ReactiveProperty<float>(StartAltitude);

        void Start()
        {
            _input.Move
                .WithLatestFrom(_altitude, CalcVelocity)
                .Subscribe(v => _velocity.Value = v)
                .AddTo(this);

            _input.Move
                .Skip(1)
                .First()
                // TODO: 徐々に加速する
                .Subscribe(_ => _fallSpeed.Value = _param.Gravity)
                .AddTo(this);

            this.UpdateAsObservable()
                .WithLatestFrom(_fallSpeed, (_, v) => v)
                .Select(v => v * Time.deltaTime)
                .Subscribe(v => _altitude.Value -= v)
                .AddTo(this);
        }

        private Vector2 CalcVelocity(Vector2 v, float altitude)
        {
            return v * _param.MoveSpeed * altitude;
        }
    }
}
