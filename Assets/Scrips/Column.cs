using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    public int id;
    // void OnCollisionEnter2D(Collision2D other)
    // {
    //     if(other.gameObject.CompareTag(TagCounts.LIMIT)){
    //         Destroy(gameObject);
    //     }
    // }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(TagCounts.LIMIT)){
            Destroy(gameObject);
        }
    }
}
