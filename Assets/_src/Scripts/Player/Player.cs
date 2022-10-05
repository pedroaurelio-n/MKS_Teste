using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PedroAurelio.SOEventSystem;
 
namespace PedroAurelio.MKS
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Health))]
    public class Player : MonoBehaviour, IDestroyable
    {
        public static GameObject PlayerObject;

        public Health Health { get; private set; }

        [Header("Events")]
        [SerializeField] private GameEvent endEvent;

        private void Awake()
        {
            if (PlayerObject == null)
                PlayerObject = gameObject;

            Health = GetComponent<Health>();
        }

        public void Destroy()
        {
            endEvent?.RaiseEvent();
            gameObject.SetActive(false);
        }
    }
}