using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Random = UnityEngine.Random;

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

        public IReadOnlyReactiveProperty<Vector2> Shake => _shake;
        private readonly ReactiveProperty<Vector2> _shake = new ReactiveProperty<Vector2>();

        public IReadOnlyReactiveProperty<float> Torque => _torque;
        private readonly ReactiveProperty<float> _torque = new ReactiveProperty<float>();

        private readonly ReactiveProperty<float> _fallSpeed = new ReactiveProperty<float>();

        public IReadOnlyReactiveProperty<float> Altitude => _altitude;
        private readonly ReactiveProperty<float> _altitude = new ReactiveProperty<float>(StartAltitude);

        void Start()
        {
            _torque.Value = _param.Torque;

            _input.Move
                .WithLatestFrom(_altitude, CalcVelocity)
                .Subscribe(v => _velocity.Value = v)
                .AddTo(this);

            _input.Move
                .Skip(1)
                .First()
                .Do(_ => _fallSpeed.Value = _param.FallSpeed)
                .ContinueWith(_ => this.UpdateAsObservable())
                .Subscribe(_ => Accelerate())
                .AddTo(this);

            this.UpdateAsObservable()
                .Select(_ => _fallSpeed.Value)
                .Select(v => v * Time.deltaTime)
                .Subscribe(v => _altitude.Value -= v)
                .AddTo(this);

            this.UpdateAsObservable()
                .Select(_ => RandomShake())
                .WithLatestFrom(_altitude, CalcVelocity)
                .Subscribe(x => _shake.Value = x)
                .AddTo(this);
        }

        private Vector2 CalcVelocity(Vector2 v, float altitude)
        {
            return v * _param.MoveSpeed * altitude;
        }

        private void Accelerate()
        {
            _fallSpeed.Value += _param.FallSpeedAcceleration * Time.deltaTime;
            _torque.Value += _param.TorqueAcceleration * Time.deltaTime;
        }

        private Vector2 RandomShake()
        {
            return Random.insideUnitCircle * _param.ShakePower;
        }

        public IObservable<Vector2> Impact()
        {
            return _altitude.First(a => a < _param.MinAltitude)
                .Select(_ => transform.position)
                .Select(v => new Vector2(v.x, v.y));
        }
    }
}
