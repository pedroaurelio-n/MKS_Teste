using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace PedroAurelio.MKS
{
    public class Health : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private int maxHealth;

        private int _currentHealth;

        private void Awake() => _currentHealth = maxHealth;

        public void ModifyHealth(int value)
        {
            _currentHealth += value;

            if (_currentHealth <= 0f)
                Die();
        }

        public void Die()
        {
            _currentHealth = 0;
            gameObject.SetActive(false);
        }
    }
}