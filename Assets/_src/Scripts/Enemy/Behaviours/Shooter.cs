using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace PedroAurelio.MKS
{
    [RequireComponent(typeof(MoveForward))]
    [RequireComponent(typeof(Rotate))]
    public class Shooter : Enemy
    {
        [Header("Shooter Settings")]
        [SerializeField] private float minDistanceToShoot;

        private void Update()
        {
            if (_Target == null)
                return;

            var distanceToTarget = Vector2.Distance(_Target.position, transform.position);

            if (distanceToTarget > minDistanceToShoot)
            {
                _Shoot?.SetShootInput(false);
                _Move.SetForwardInput(true);
            }
            else
            {
                _Shoot?.SetShootInput(true);
                _Move.SetForwardInput(false);
            }

            RotateTowardsTarget();
        }
    }
}