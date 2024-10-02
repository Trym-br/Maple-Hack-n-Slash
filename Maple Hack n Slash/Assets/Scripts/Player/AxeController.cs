using UnityEngine;

public class AxeController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    // private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("triggered by: " + other.gameObject.name);
        if (other.gameObject.tag == "Enemy")
        {
            Attack(other);
        }
    }
    private void Attack(Collider2D other)
    {
        other.gameObject.GetComponent<Health>().TakeDamage(1);
    }
}
