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
        Destroy(collision.gameObject);
        Destroy(gameObject);

        ScoreManager.Instance.AddScore();
    }
}
