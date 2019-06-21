using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 0.5f;
    public float damage = 0.4f;

    void OnTriggerEnter(Collider other) {
        if (other.tag == "PlayerProjectile") {
            health -= other.GetComponent<Projectile>().damage;
            Destroy(other.gameObject);
            if (health <= 0) {
                Destroy(gameObject);
            }
        } else if (other.tag == "Player") {
            health -= 0.1f;
            other.GetComponent<PlayerManager>().health -= damage;
        }
    }
}
