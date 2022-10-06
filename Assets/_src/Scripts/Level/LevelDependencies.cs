using UnityEngine;
 
namespace PedroAurelio.MKS
{
    public class LevelDependencies : MonoBehaviour
    {
        public static GameObject Player;
        public static Transform Dynamic;

        [Header("Dependencies")]
        [SerializeField] private GameObject player;
        [SerializeField] private Transform dynamic;

        private void Awake()
        {
            Player = player;
            Dynamic = dynamic;
        }
    }
}