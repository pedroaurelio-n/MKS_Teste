using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace PedroAurelio.MKS
{
    public class HealthValueHandler : MonoBehaviour
    {
        private static Transform _canvasTransform;
        private static List<HealthValue> _healthList;

        private void Awake()
        {
            _healthList = new List<HealthValue>();
            _canvasTransform = transform;
        }

        private void Update()
        {
            for (int i = 0; i < _healthList.Count; i++)
            {
                _healthList[i].UpdatePosition();
            }
        }

        public static void AttachBarToCanvas(HealthValue health)
        {
            _healthList.Add(health);
            health.transform.SetParent(_canvasTransform);
        }

        private void OnDisable() => _healthList.Clear();
    }
}