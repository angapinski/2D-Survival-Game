using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour {

    public float currentSpeed;
    public float startSpeed;
    public float maxSpeed;

    public float jumpSpeed;

    public KeyCode jumpKey = KeyCode.Space;

    public Sprite[] walkSprites;
    public Sprite idleSprite;

    RaycastHit2D hit;

    bool isWalking;
    bool isGrounded;
    bool facingRight;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        Rigidbody2D r2D = GetComponent<Rigidbody2D>();

        r2D.velocity = new Vector2(Input.GetAxis("Horizontal") * currentSpeed, r2D.velocity.y);
        r2D.freezeRotation = true;

        if (Input.GetAxis("Horizontal") > 0)
        {
            facingRight = true;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            facingRight = false;
        }

        if (facingRight)
        {
            hit = Physics2D.Raycast(new Vector2(transform.position.x -.5f, transform.position.y), Vector2.down);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            hit = Physics2D.Raycast(new Vector2(transform.position.x + .5f, transform.position.y), Vector2.down);
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (r2D.velocity.magnitude > 0.1f)
        {
            if (!isWalking)
            {
                StartCoroutine(Walk());
            }
        }

        
        Debug.Log(Vector2.Distance(new Vector2(transform.position.x, transform.position.y), hit.collider.transform.position));

        if (hit.distance < .65f)
        {
            isGrounded = true;
            Debug.Log("On Ground");
        }
        else
        {
            isGrounded = false;
            Debug.Log("Off Ground");
        }

        if (isGrounded)
        {
            if (Input.GetKeyDown(jumpKey))
            {
                r2D.velocity = new Vector2(r2D.velocity.x, jumpSpeed);
            }
        }

        if (!isWalking)
        {
            GetComponent<SpriteRenderer>().sprite = idleSprite;
        }
    }

        IEnumerator Walk()
        {
            isWalking = true;
            GetComponent<SpriteRenderer>().sprite = walkSprites[0];
            yield return new WaitForSeconds(0.25f);
            GetComponent<SpriteRenderer>().sprite = walkSprites[1];
            yield return new WaitForSeconds(0.25f);
            isWalking = false;
        }
}
