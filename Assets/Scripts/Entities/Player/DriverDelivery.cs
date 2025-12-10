using UnityEngine;

namespace Entities.Player
{
    public class DriverDelivery : MonoBehaviour
    {
        private bool hasPackage;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Package"))
            {
                Debug.Log("Package picked up!");
                hasPackage = true;
            }
            else if (other.CompareTag("Customer") && hasPackage)
            {
                Debug.Log("Customer served!");
                hasPackage = false;
            }
        }
    }
}
