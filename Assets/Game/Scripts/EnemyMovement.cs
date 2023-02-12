using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetStraightVelocity();
    }
    private void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x + 0.1f, rb.velocity.y);
    }
    private void SetStraightVelocity()
    {
        rb.velocity = transform.right * 5;
    }
}
