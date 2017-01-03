using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public float MaxVelocity;

    public float StartNudgeStrength;

    public int MaxBounces;
    public float BounceNudgeStrength;

    [HideInInspector]
    public PlayerSide LastHitter;

    private int bounces;

    private Rigidbody2D rb;

	void Awake()
	{
	    rb = GetComponent<Rigidbody2D>();
	}

    void Start() 
    {
        LastHitter = PlayerSide.None;

        // Nudge the rigid body at start
        var randSide = Random.Range(0, 2)*2 - 1;
        var randDir = new Vector2(randSide, Random.Range(-1f, 1f));
        rb.AddForce(randDir.normalized * StartNudgeStrength, ForceMode2D.Impulse);
    }
    
    void Update() 
    {
        // Quick hack to remove really long and boring shots
        if (Input.GetKeyDown("space"))
        {
            rb.AddForce( - transform.position.normalized * 2f, ForceMode2D.Impulse);
        }

        if (rb.velocity.magnitude > MaxVelocity)
        {
            rb.velocity = rb.velocity.normalized * MaxVelocity;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            LastHitter = other.gameObject.GetComponent<Player>().Side;
            rb.AddForce(-transform.position.normalized * 2f, ForceMode2D.Impulse);
        }

        bounces++;

        if (bounces <= MaxBounces)
        {
            rb.AddForce(rb.velocity.normalized * BounceNudgeStrength, ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Tile")
        {
            other.gameObject.GetComponent<Tile>().CurrentHolder = LastHitter;
        }
    }
}
