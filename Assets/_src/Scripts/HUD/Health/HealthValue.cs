using UnityEngine;
using TMPro;
 
namespace PedroAurelio.MKS
{
    public class HealthValue : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private TextMeshProUGUI healthNumber;

        private Transform _target;
        private Vector2 _offset;

        public void Initialize(Transform target, Vector2 offset)
        {
            _target = target;
            _offset = offset;
            HealthValueHandler.AttachBarToCanvas(this);
        }

        public void UpdatePosition()
        {
            if (_target != null)
                transform.position = _target.position + (Vector3)_offset;
        }

        public void UpdateHealth(float currentHealth, float maxHealth) => healthNumber.text = $"{currentHealth}/{maxHealth}";
    }
}