using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    void Start()
    {
        Vector3 size = GetComponent<SpriteRenderer>().bounds.size;
        float max = Mathf.Max(size.x, size.y, size.z);
        GetComponent<BoxCollider>().size = new Vector3(max, max, max);
        transform.localScale = new Vector3(1 / max, 1 / max, 1 / max);
    }
}
