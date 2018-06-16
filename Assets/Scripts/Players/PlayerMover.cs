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
                .Subscribe(_ => Move())
                .AddTo(this);
        }

        private void Move()
        {
            var velocity = transform.TransformDirection(_core.Velocity.Value * Time.deltaTime);

            var pos = transform.localPosition;
            pos.x += velocity.x;
            pos.y += velocity.y;

            var torque = _core.Torque.Value * Time.deltaTime;
            var rotation = transform.rotation * Quaternion.AngleAxis(torque, Vector3.forward);

            transform.SetPositionAndRotation(pos, rotation);
        }
    }
}
