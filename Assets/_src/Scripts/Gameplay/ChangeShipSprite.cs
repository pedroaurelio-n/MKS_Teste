using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace PedroAurelio.MKS
{
    public class ChangeShipSprite : MonoBehaviour
    {
        [SerializeField] private Sprite fullSprite;
        [SerializeField] private Sprite brokenSprite;
        [SerializeField] private Sprite destroyedSprite;

        private SpriteRenderer _spriteRenderer;

        private const float TWO_THIRDS = 0.67f;
        private const float ONE_THIRD = 0.34f;

        private void Awake() => _spriteRenderer = GetComponent<SpriteRenderer>();

        public void UpdateShipSprite(int currentHealth, int maxHealth)
        {
            var healthPercentage = (float)currentHealth / (float)maxHealth;

            if (healthPercentage > TWO_THIRDS)
            {
                _spriteRenderer.sprite = fullSprite;
                return;
            }

            if (healthPercentage < TWO_THIRDS && healthPercentage > ONE_THIRD)
            {
                _spriteRenderer.sprite = brokenSprite;
                return;
            }

            _spriteRenderer.sprite = destroyedSprite;
        }
    }
}