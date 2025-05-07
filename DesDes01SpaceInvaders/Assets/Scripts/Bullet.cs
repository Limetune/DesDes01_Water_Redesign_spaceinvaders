using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 10;
    public float lifeTime = 2;
    
    
    // Start is called before the first frame update
    void Update()
    {
        Destroy(gameObject, lifeTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Pellet"))
        {
            return;
        }
        else
        {
            Destroy(collision.gameObject);
            Destroy(gameObject); 
        }
       
    }

    // Update is called once per frame
    public void SetDirection(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;
    }
}
