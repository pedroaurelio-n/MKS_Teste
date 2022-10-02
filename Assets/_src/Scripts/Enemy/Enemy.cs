using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace PedroAurelio.MKS
{
    [RequireComponent(typeof(Health))]
    public abstract class Enemy : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private int collisionDamage;

        protected MoveForward _Move;
        protected Rotate _Rotate;

        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();

            TryGetComponent<MoveForward>(out _Move);
            TryGetComponent<Rotate>(out _Rotate);
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