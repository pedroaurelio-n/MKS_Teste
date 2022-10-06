using UnityEngine;
using UnityEngine.Events;
 
namespace PedroAurelio.SOEventSystem
{
    public class UnityEventListener : BaseEventListener
    {
        [Header("Event Settings")]
        [SerializeField] private UnityEvent response;

        protected override void InvokeEvent()
        {
            response?.Invoke();
            
            base.InvokeEvent();
        }
    }
}