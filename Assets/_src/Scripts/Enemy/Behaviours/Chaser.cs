using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace PedroAurelio.MKS
{
    [RequireComponent(typeof(MoveForward))]
    [RequireComponent(typeof(Rotate))]
    public class Chaser : Enemy
    {
        [Header("Dependencies")]
        [SerializeField] private Transform target;

        [Header("Settings")]
        [SerializeField, Range(0f, 1f)] private float rotationThreshold = 0.1f;

        private void Start()
        {
            _Move.SetForwardInput(true);
        }

        private void Update()
        {
            var directionToTarget = target.position - transform.position;
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
    }
}