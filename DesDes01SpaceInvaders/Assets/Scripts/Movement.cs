using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    // Start is called before the first frame update
    public float speed = 5f;
    private Vector2 direction = Vector2.right;
    private List<Transform> segments = new List<Transform>();
    public Transform segmentPrefab;

    void Start()
    {
        segments.Add(this.transform);
    }

    void Update()
    {
        Vector3 position = transform.position;

        // Update the position of the player based on the input
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            position.x -= speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            position.x += speed * Time.deltaTime;
        }

        // Clamp the position of the character so they do not go out of bounds
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
        position.x = Mathf.Clamp(position.x, leftEdge.x, rightEdge.x);

        // Set the new position
        transform.position = position;
    }

    
}
