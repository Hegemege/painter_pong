using UnityEngine;
using System.Collections;

public enum PlayerSide
{
    None = -1,
    Left = 0,
    Right = 1
}

public class Player : MonoBehaviour
{
    public float MaxVelocity;

    public float MovementSpeed;

    public PlayerSide Side;
    public string ControlScheme;

    private General general;
    private Rigidbody2D rb;

    private float VerticalInput
    {
        get { return Input.GetAxis(ControlScheme); }
    }

	void Awake() 
	{
        general = GameObject.Find("General").GetComponent<General>();
	    rb = GetComponent<Rigidbody2D>();
	}

    void Start() 
    {
    
    }
    
    void Update()
    {
        var dt = Time.deltaTime;

        //rb.velocity = new Vector2(0f, VerticalInput * MovementSpeed);
        rb.AddForce(new Vector2(0f, VerticalInput) * MovementSpeed, ForceMode2D.Impulse);

        if (rb.velocity.magnitude > MaxVelocity)
        {
            rb.velocity = rb.velocity.normalized * MaxVelocity;
        }
    }
}
