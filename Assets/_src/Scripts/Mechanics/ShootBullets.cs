using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.InputSystem;
using PedroAurelio.SOEventSystem;
 
namespace PedroAurelio.MKS
{
    public class ShootBullets : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private IntEvent ammoEvent;
        [SerializeField] private ShootingPattern defaultPattern;
        [SerializeField] private Transform spawnPosition;
        [SerializeField] private Transform dynamic;
        [SerializeField] private Animator shootAnimation;

        [Header("Settings")]
        [SerializeField, Range(0f, 360f)] private float initialRotation;

        private ShootingPattern _pattern;
        private int _ammoRemaining;

        private ObjectPool<Bullet> _bulletPool;

        private bool _shootInput;
        private float _fireTime;
        private Vector3 _rotation;

        private void Awake()
        {
            _bulletPool = new ObjectPool<Bullet>(OnCreateBullet, OnGetBullet, OnReleaseBullet);

            if (spawnPosition == null)
                spawnPosition = transform;
        }

        private void Start()
        {
            InitializePattern(defaultPattern);
            _fireTime = _pattern.StartDelay;
        }

        private void InitializePattern(ShootingPattern pattern)
        {
            var oldPattern = _pattern;
            _pattern = pattern;

            if (_pattern == oldPattern && _pattern != defaultPattern)
                _ammoRemaining += pattern.MaxAmmo;
            else
            {
                if (_pattern.MaxAmmo <= 0)
                    _ammoRemaining = -1;
                else
                    _ammoRemaining = _pattern.MaxAmmo;
            }


            ammoEvent?.RaiseEvent(_ammoRemaining);

            if (!_pattern.IsAiming)
                _rotation.z = initialRotation;
        }

        #region Pooling Methods
        private Bullet OnCreateBullet()
        {
            var bullet = Instantiate(_pattern.BulletPrefab, dynamic);
            bullet.SetPool(_bulletPool);
            return bullet;
        }

        private void OnGetBullet(Bullet bullet) => bullet.gameObject.SetActive(true);
        private void OnReleaseBullet(Bullet bullet) => bullet.gameObject.SetActive(false);
        #endregion

        private void FixedUpdate()
        {
            if (_fireTime > 0f)
            {
                _fireTime -= Time.deltaTime;
                return;
            }

            if (_pattern.NeedInput)
            {
                if (_shootInput) Shoot();
                return;
            }
            
            Shoot();
        }

        private void Shoot()
        {
            UpdateRotation();

            var missRange = new Vector3(0f, 0f, _pattern.MissAngleOpening * Random.Range(-_pattern.MissRate, _pattern.MissRate));
            var direction = _rotation + missRange + new Vector3(0f, 0f, _pattern.AngleOffset);

            if (_pattern.IsAiming)
            {
                var currentRotation = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
                direction += currentRotation;
            }

            if (_pattern.SideCount == 1)
            {
                var bullet = _bulletPool.Get();
                bullet.Initialize(spawnPosition.position, direction, _pattern.BulletSpeed);
            }
            else
            {
                var angleOffset = Vector3.zero;
                float angleDivision;

                if (_pattern.AngleOpening != 360f)
                    angleDivision = _pattern.AngleOpening / (_pattern.SideCount - 1);
                else
                    angleDivision = _pattern.AngleOpening / _pattern.SideCount;

                for (int i = 0; i < _pattern.SideCount; i++)
                {
                    angleOffset.z = angleDivision * i;

                    var bullet = _bulletPool.Get();
                    bullet.Initialize(spawnPosition.position, direction + angleOffset, _pattern.BulletSpeed);
                }
            }

            if (shootAnimation != null)
                shootAnimation.SetTrigger("Shoot");

            _fireTime = _pattern.FireRate;

            if (_ammoRemaining > 0)
            {
                _ammoRemaining--;

                ammoEvent?.RaiseEvent(_ammoRemaining);

                if (_ammoRemaining == 0)
                    ChangePattern(defaultPattern);
            }
        }

        private void UpdateRotation()
        {
            if (_pattern.IsAiming)
                _rotation.z = -_pattern.AngleOpening * 0.5f;
            else
                _rotation.z += _pattern.SpinRate;
        }

        public void ChangePattern(ShootingPattern newPattern)
        {
            InitializePattern(newPattern);
        }

        public void SetShootInput(bool value) => _shootInput = value;
        public void SetShootInput(InputAction.CallbackContext ctx)
        {
            switch (ctx.phase)
            {
                case InputActionPhase.Performed: SetShootInput(true); break;
                case InputActionPhase.Canceled: SetShootInput(false); break;
                default: break;
            }
        }
    }
}