using UnityEngine;

namespace Entities.Player
{
    public class Driver : MonoBehaviour
    {
        [SerializeField] private float steerSpeed = 1f;
        [SerializeField] private float accelSpeed = 1f;

        [SerializeField] private float steerInput;
        [SerializeField] private float accelInput;
        private InputSystem_Actions _driverInput;

        private void Awake()
        {
            _driverInput = new InputSystem_Actions();
        }

        private void Update()
        {
            steerInput = _driverInput.Driver.Rotate.ReadValue<float>();
            accelInput = _driverInput.Driver.Accel.ReadValue<float>();

            var steerValue = steerInput * steerSpeed * Time.deltaTime;
            var movementValue = accelInput * accelSpeed * Time.deltaTime;

            transform.Rotate(0f, 0f, -steerValue); //2d é no Z
            transform.Translate(0f, movementValue, 0f);
        }

        private void OnEnable()
        {
            _driverInput.Driver.Enable();
        }

        private void OnDisable()
        {
            _driverInput.Driver.Disable();
        }
    }
}