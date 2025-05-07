using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public float Life = 3;

    void Awake()
    {
        Destroy(gameObject, Life);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            FindObjectOfType<pointCounter>().AddPoints(enemy.score);
            Destroy(collision.gameObject); // f�rst�r fienden
            Destroy(gameObject); // f�rst�r kulan
        }

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
