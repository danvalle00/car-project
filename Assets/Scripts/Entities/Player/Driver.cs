using TMPro;
using UnityEngine;

namespace Entities.Player
{
    public class Driver : MonoBehaviour
    {
        [SerializeField]
        private float steerSpeed = 1f;

        [SerializeField]
        private float regularSpeed = 1f;
        private float accelSpeed;

        [SerializeField]
        private float steerInput;

        [SerializeField]
        private float accelInput;

        [SerializeField]
        private float boostSpeed = 6f;

        private InputSystem_Actions _driverInput;
        private TMP_Text infoText;

        private void Awake()
        {
            _driverInput = new InputSystem_Actions();
            accelSpeed = regularSpeed;
        }

        private void Start()
        {
            infoText.gameObject.SetActive(false);
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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Boost"))
            {
                Debug.Log("Speed Boost!");
                accelSpeed = boostSpeed;
                Destroy(collision.gameObject);
                infoText.gameObject.SetActive(true);
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            accelSpeed = regularSpeed;
            infoText.gameObject.SetActive(false);
        }
    }
};
