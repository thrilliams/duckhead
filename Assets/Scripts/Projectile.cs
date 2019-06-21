using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public float speed;
    public float lifetime;
    public Vector3 direction;
    public Vector3 scale;

    public void Init()
    {
        transform.localScale = Vector3.Scale(scale, transform.localScale);
    }

    void Update()
    {
        transform.position += direction * Time.deltaTime * speed;

        lifetime -= Time.deltaTime;
        if (lifetime <= 0) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Solid") {
            Destroy(gameObject);
        }
    }
}