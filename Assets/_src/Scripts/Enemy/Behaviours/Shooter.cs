using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace PedroAurelio.MKS
{
    [RequireComponent(typeof(MoveForward))]
    [RequireComponent(typeof(Rotate))]
    public class Shooter : Enemy
    {
        [Header("Dependencies")]
        [SerializeField] private Transform target;

        [Header("Settings")]
        [SerializeField, Range(0f, 1f)] private float rotationThreshold = 0.1f;
        [SerializeField] private float minimumDistance;

        private void Update()
        {
            var distanceToTarget = Vector2.Distance(target.position, transform.position);

            if (distanceToTarget > minimumDistance)
            {
                _Shoot?.SetShootInput(false);
                _Move.SetForwardInput(true);
            }
            else
            {
                _Shoot?.SetShootInput(true);
                _Move.SetForwardInput(false);
            }

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