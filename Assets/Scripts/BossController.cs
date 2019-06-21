using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public float slapInterval;
    public float slapDamage;
    public float damage;

    public Slider slider;

    public float maxHealth = 50;
    float health;

    float timer;
    Animator animator;

    public float damageCooldown;
    float damageTimer;


    void Start() {
        timer = slapInterval;
        animator = GetComponent<Animator>();
        health = maxHealth;
    }

    void Update() {
        if (damageTimer > 0) {
            damageTimer -= Time.deltaTime;
        }

        timer -= Time.deltaTime;

        if (timer < 0) {
            timer = slapInterval;
            animator.SetTrigger("Smashu");
        }

        if (health <= 0) {
            print("you are a winner");
            Destroy(gameObject);
        }

        slider.value = health / maxHealth;
    }

    void OnTriggerStay(Collider other) {
        PlayerManager player = other.GetComponent<PlayerManager>();
        Projectile projectile = other.GetComponent<Projectile>();

        if (player != null && damageTimer <= 0) {
            if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Smashu") {
                player.health -= slapDamage;
            } else {
                player.health -= damage;
            }
            damageTimer = damageCooldown;
        }

        if (projectile != null) {
            health -= projectile.damage;
            Destroy(other.gameObject);
        }
    }
}
