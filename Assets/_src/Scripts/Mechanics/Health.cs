using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace PedroAurelio.MKS
{
    public class Health : MonoBehaviour
    {
        [Header("HUD Indicator")]
        [SerializeField] private HealthValue healthValuePrefab;
        [SerializeField] private Vector2 valueOffset;

        [Header("Settings")]
        [SerializeField] private int maxHealth;

        private IDestroyable _destroyable;
        private HealthValue _healthValue;
        private ChangeShipSprite _shipSprite;

        private int _currentHealth;

        private void Awake()
        {
            _shipSprite = GetComponentInChildren<ChangeShipSprite>();

            _currentHealth = maxHealth;

            if (!TryGetComponent<IDestroyable>(out _destroyable))
                Debug.LogWarning($"Object needs to have a IDestroyable component to use Health.");
        }

        private void Start()
        {
            if (healthValuePrefab != null)
            {
                _healthValue = Instantiate(healthValuePrefab, transform.position, Quaternion.identity);
                _healthValue.Initialize(transform, valueOffset);

                _healthValue.UpdateHealth(_currentHealth, maxHealth);
            }

            _shipSprite.UpdateShipSprite(_currentHealth, maxHealth);
        }

        public void ModifyHealth(int value)
        {
            _currentHealth += value;

            _healthValue.UpdateHealth(_currentHealth, maxHealth);
            _shipSprite.UpdateShipSprite(_currentHealth, maxHealth);

            if (_currentHealth <= 0f)
                Die();
        }

        public void Die()
        {
            _currentHealth = 0;
            _healthValue.gameObject.SetActive(false);
            _destroyable.Destroy();
        }
    }
}