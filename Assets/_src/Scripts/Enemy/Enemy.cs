using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace PedroAurelio.MKS
{
    [RequireComponent(typeof(Health))]
    public abstract class Enemy : MonoBehaviour
    {
        
        [Header("General Settings")]
        [SerializeField] private int collisionDamage;
        [SerializeField, Range(0f, 1f)] private float rotationThreshold = 0.1f;

        protected Transform _Target;

        protected MoveForward _Move;
        protected Rotate _Rotate;
        protected ShootBullets _Shoot;

        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();

            TryGetComponent<MoveForward>(out _Move);
            TryGetComponent<Rotate>(out _Rotate);
            _Shoot = GetComponentInChildren<ShootBullets>();
        }

        public void Initialize(Transform target, Vector3 position)
        {
            _Target = target;
            transform.position = position;
            SetInitialRotation();
        }

        private void SetInitialRotation()
        {
            var directionToPlayer = _Target.transform.position - transform.position;
            var angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }

        protected void RotateTowardsTarget()
        {
            if (_Target == null || _Rotate == null)
                return;

            var directionToTarget = _Target.position - transform.position;
            var dotProduct = Vector2.Dot(transform.up, directionToTarget.normalized);

            if (Mathf.Abs(dotProduct) < rotationThreshold)
            {
                _Rotate.SetRotationDirection(0f);
                return;
            }

            if (dotProduct >= 0f)
                _Rotate.SetRotationDirection(1f);
            else
                _Rotate.SetRotationDirection(-1f);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<Player>(out Player player))
            {
                player.Health.ModifyHealth(-collisionDamage);
                _health.ModifyHealth(-int.MaxValue);
            }
        }
    }
}