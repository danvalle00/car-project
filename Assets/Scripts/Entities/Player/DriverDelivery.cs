using UnityEngine;

namespace Entities.Player
{
    [RequireComponent(typeof(ParticleSystem))]
    public class DriverDelivery : MonoBehaviour
    {
        private bool hasPackage;
        private ParticleSystem packageEffect;

        [SerializeField]
        private float destroyDelay = 1f;

        private void Start()
        {
            packageEffect = GetComponent<ParticleSystem>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Package") && !hasPackage)
            {
                packageEffect.Play();
                Destroy(other.gameObject, destroyDelay);
                hasPackage = true;
            }
            else if (other.CompareTag("Customer") && hasPackage)
            {
                Debug.Log("Customer served!");
                hasPackage = false;
                packageEffect.Stop();
                Destroy(other.gameObject);
            }
        }
    }
}
