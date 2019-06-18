using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float size;

    void Start()
    {
        // setup bounding boxes
        Vector3 spriteSize = GetComponent<SpriteRenderer>().bounds.size;
        float max = Mathf.Max(spriteSize.x, spriteSize.y, spriteSize.z);
        GetComponent<BoxCollider>().size = new Vector3(max, max, max);
        max = size / max;
        transform.localScale = new Vector3(max, max, max);
    }
}
