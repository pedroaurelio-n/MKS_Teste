using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace PedroAurelio.MKS
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Health))]
    public class Player : MonoBehaviour
    {
        public static GameObject PlayerObject;

        public Health Health { get; private set; }

        private void Awake()
        {
            if (PlayerObject == null)
                PlayerObject = gameObject;

            Health = GetComponent<Health>();
        }
    }
}