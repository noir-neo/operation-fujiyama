using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Players
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField]
        private PlayerCore _core;

        void Start()
        {
            this.UpdateAsObservable()
                .WithLatestFrom(_core.Velocity, (_, v) => v)
                .Select(v => v * Time.deltaTime)
                .Subscribe(Move)
                .AddTo(this);
        }

        private void Move(Vector2 velocity)
        {
            var pos = transform.position;
            pos.x += velocity.x;
            pos.y += velocity.y;
            transform.position = pos;
        }
    }
}
