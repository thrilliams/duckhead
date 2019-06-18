using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    void Start()
    {
        Vector3 size = GetComponent<SpriteRenderer>().bounds.size;
        GetComponent<BoxCollider>().center = new Vector3(0.05f, 0.05f, 0.05f);
        GetComponent<BoxCollider>().size = size + new Vector3(0.2f, 0.2f, 0.2f);
        float scale = 1 / Mathf.Max(size.x, size.y, size.z);
        transform.localScale = new Vector3(scale, scale, scale);
    }
}
