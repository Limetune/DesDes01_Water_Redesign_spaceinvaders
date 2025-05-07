using UnityEngine;

public class BulletSpeedPowerUp : MonoBehaviour
{
    public float boostAmount = 5f;  // Boost value (how much the bullet speed increases)
    public float duration = 5f;     // How long the boost lasts

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Check if the colliding object is the player
        {
            Shotgun shotgun = other.GetComponent<Shotgun>();
            if (shotgun != null)
            {
                Debug.Log("Power-up picked up! Boosting shotgun speed."); // Debugging line
                StartCoroutine(ApplyBoost(shotgun));
            }

            Destroy(gameObject);  // Destroy the power-up after use
        }
    }

    private System.Collections.IEnumerator ApplyBoost(Shotgun shotgun)
    {
        // Temporarily increase the shotgun's bullet speed boost
        shotgun.bulletSpeedBoost += boostAmount;
        yield return new WaitForSeconds(duration);
        shotgun.bulletSpeedBoost -= boostAmount;  // Reset the speed boost after the duration ends
    }
}
