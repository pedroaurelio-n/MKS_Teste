using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PedroAurelio.SOEventSystem;
 
namespace PedroAurelio.MKS
{
    public class Health : MonoBehaviour
    {
        public int MaxHealth { get => maxHealth; }
        public int CurrentHealth { get => _currentHealth; }

        [Header("HUD Indicator")]
        [SerializeField] private HealthValue healthValuePrefab;
        [SerializeField] private Vector2 valueOffset;

        [Header("Settings")]
        [SerializeField] private int maxHealth;
        [SerializeField] private int scoreOnDeath;

        [Header("Events")]
        [SerializeField] private IntEvent scoreEvent;

        private HealthValue _healthValue;
        private int _currentHealth;

        private void Awake() => _currentHealth = maxHealth;

        private void Start()
        {
            if (healthValuePrefab != null)
            {
                _healthValue = Instantiate(healthValuePrefab);
                _healthValue.Initialize(transform, valueOffset);

                _healthValue.UpdateHealth(_currentHealth, maxHealth);
            }
        }

        public void ModifyHealth(int value)
        {
            _currentHealth += value;

            _healthValue.UpdateHealth(_currentHealth, maxHealth);

            if (_currentHealth <= 0f)
                Die();
        }

        public void Die()
        {
            _currentHealth = 0;
            scoreEvent?.RaiseEvent(scoreOnDeath);
            _healthValue.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}