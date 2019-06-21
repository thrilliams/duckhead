using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public float size;
    public float fireRate;
    public Slider healthSlider;
    public GameObject projectile;
    public float health = 1;
    [System.NonSerialized]
    public int xdir = 1;

    SpriteRenderer SR;
    Vector3 billPos;
    GameObject bill;
    SpriteRenderer billSprite;
    float cooldown = 0;

    void Start() {
        SR = GetComponent<SpriteRenderer>();
        bill = transform.Find("Bill").gameObject;
        billPos = bill.transform.position;
        billSprite = bill.GetComponent<SpriteRenderer>();

        // setup bounding boxes
        Vector3 spriteSize = SR.bounds.size;
        float max = Mathf.Max(spriteSize.x, spriteSize.y, spriteSize.z);
        BoxCollider BC = GetComponent<BoxCollider>();
        BC.size = new Vector3(max, max, BC.size.z);
        max = size / max;
        transform.localScale = new Vector3(max, max, max);
    }

    void Update() {
        healthSlider.value = health;
        if (health <= 0) {
            Restart();
        }

        if (Input.GetButton("Fire1") && cooldown <= 0) {
            Fire();
        }

        cooldown -= Time.deltaTime;

        SR.flipX = xdir != 1;
        bill.transform.localPosition = Vector3.Scale(billPos, new Vector3(xdir, 1, 1)) - new Vector3(0, 1, 0);
        billSprite.flipX = xdir != 1;
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "EnemyProjectile") { // change to enemy
            Projectile projectile = other.GetComponent<Projectile>();
            health -= projectile.damage;
            Destroy(other.gameObject);
        }
    }

    Vector3 direction() {
        return new Vector3(xdir, 0, 0);
    }

    void Fire() {
        Projectile p = Instantiate(projectile, bill.transform.position, Quaternion.identity).GetComponent<Projectile>();
        p.direction = direction();
        p.scale = transform.localScale;
        p.Init();

        cooldown = fireRate;
    }
}
