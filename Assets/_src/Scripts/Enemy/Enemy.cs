using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace PedroAurelio.MKS
{
    [RequireComponent(typeof(Health))]
    public class Enemy : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private int collisionDamage;

        private Health _health;

        private void Awake() => _health = GetComponent<Health>();

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