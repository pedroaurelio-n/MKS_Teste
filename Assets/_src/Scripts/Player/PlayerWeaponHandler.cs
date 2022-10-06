using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
 
namespace PedroAurelio.MKS
{
    public class PlayerWeaponHandler : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private ShootBullets frontShot;
        [SerializeField] private List<ShootBullets> sideShots;

        public void FireFrontShot(InputAction.CallbackContext ctx)
        {
            switch (ctx.phase)
            {
                case InputActionPhase.Performed:
                    frontShot.SetShootInput(true);

                    foreach (ShootBullets shoot in sideShots)
                        shoot.SetShootInput(false);
                    break;

                case InputActionPhase.Canceled:
                    frontShot.SetShootInput(false);
                    break;
                    
                default: break;
            }
        }

        public void FireSideShot(InputAction.CallbackContext ctx)
        {
            switch (ctx.phase)
            {
                case InputActionPhase.Performed:
                    foreach (ShootBullets shoot in sideShots)
                        shoot.SetShootInput(true);

                    frontShot.SetShootInput(false);
                    break;
                    
                case InputActionPhase.Canceled:
                    foreach (ShootBullets shoot in sideShots)
                        shoot.SetShootInput(false);
                        
                    break;
                    
                default: break;
            }
        }
    }
}