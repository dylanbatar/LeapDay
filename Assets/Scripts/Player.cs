using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  Rigidbody2D body;
  SpriteRenderer sprite;
  float vertical;
  bool direction = true;
  public float runSpeed = 10.0f;
  public float jumpForce = 20.0f;

  public bool touchingFloor = true;

  void Start()
  {
    body = GetComponent<Rigidbody2D>();
    sprite = GetComponent<SpriteRenderer>();

  }

  private void FixedUpdate()
  {
    body.velocity = new Vector2((direction ? 1 : -1) * runSpeed, 0);
    if (Input.GetKeyDown(KeyCode.Space))
    {
      touchingFloor = false;
      Jump(jumpForce);
    }

  }
  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "Walls")
    {
      sprite.flipX = direction;
      direction = !direction;
    }
  }

  public void Jump(float inpulse = 10.0f)
  {
    Debug.Log("space");
    body.AddForce(new Vector2(0, inpulse), ForceMode2D.Impulse);
    touchingFloor = true;
  }
}
