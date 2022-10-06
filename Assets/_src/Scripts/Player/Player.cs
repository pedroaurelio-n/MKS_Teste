using UnityEngine;
using PedroAurelio.SOEventSystem;
 
namespace PedroAurelio.MKS
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Health))]
    public class Player : MonoBehaviour, IDestroyable
    {
        public Health Health { get; private set; }

        [Header("Dependencies")]
        [SerializeField] private GameObject deathAnimation;

        [Header("Events")]
        [SerializeField] private GameEvent endEvent;

        private void Awake() => Health = GetComponent<Health>();

        public void Destroy()
        {
            endEvent?.RaiseEvent();
            var death = Instantiate(deathAnimation, transform.position, Quaternion.identity, LevelDependencies.Dynamic);
            gameObject.SetActive(false);
        }
    }
}