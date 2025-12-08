using UnityEngine;

namespace Entities.Player
{
    public class DriverCollision : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log("Collider with: " + other.gameObject.name);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Trigger with: " + other.gameObject.name);
        }
    }
}