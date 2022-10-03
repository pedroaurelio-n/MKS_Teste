using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PedroAurelio.SOEventSystem;
 
namespace PedroAurelio.MKS
{
    public class Health : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private int maxHealth;
        [SerializeField] private int scoreOnDeath;

        [Header("Events")]
        [SerializeField] private IntEvent scoreEvent;

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
            scoreEvent?.RaiseEvent(scoreOnDeath);
            gameObject.SetActive(false);
        }
    }
}