using UnityEngine;
 
namespace PedroAurelio.MKS
{
    [RequireComponent(typeof(MoveForward))]
    [RequireComponent(typeof(Rotate))]
    public class Chaser : Enemy
    {
        private void Start() => _Move.SetForwardInput(true);

        private void Update() => RotateTowardsTarget();
    }
}