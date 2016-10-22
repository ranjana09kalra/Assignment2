using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    //PRIVATE INSTANCE VARIABLES
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private float _move;
    private float _jump;
    private bool _IsFacingRight;
    private bool _IsGrounded;

    //PUBLIC INSTANCE VARIABLES(FOR TESTING)
    public float Velocity = 10f;
    public float JumpForce = 100f;
    public Camera camera;
    public Transform SpawnPoint;

    [Header("Sound Clips")]
    public AudioSource JumpSound;
    public AudioSource DeathSound;
    public AudioSource CoinSound;
    // Use this for initialization
    void Start()
    {
        this._initialize();
    }

    // Update is called once per frame (physics)
    void FixedUpdate()
    {
        if (this._IsGrounded)
        {
            //check if input is present for movement
            this._move = Input.GetAxis("Horizontal");
            if (this._move > 0f)
            {
                this._move = 1;
                this._IsFacingRight = true;
                this._flip();
            }

            else if (this._move < 0)
            {
                this._move = -1;
                this._IsFacingRight = false;
                this._flip();
            }

            else
            {
                this._move = 0f;
            }
            //chekc if input is present for jumping

            if (Input.GetKeyDown(KeyCode.Space))
            {
                this._jump = 1f;
                this.JumpSound.Play();
            }
            this._rigidbody.AddForce(new Vector2(this._move * this.Velocity, this._jump * this.JumpForce), ForceMode2D.Force);
        }
        else
        {
            this._move = 0f;
            this._jump = 0f;

        }
        this.camera.transform.position = new Vector3(this._transform.position.x, this._transform.position.y, -10f);

        Debug.Log(this._IsGrounded);
    }

    //PRIVATE METHODS
    // Methods to initialize variables and objects and call them
    private void _initialize()
    {
        this._transform = GetComponent<Transform>();
        this._rigidbody = GetComponent<Rigidbody2D>();
        this._move = 0f;
        this._IsFacingRight = true;
        this._IsGrounded = false;
    }

    //Method to flip the character bitmap across x axis

    private void _flip()
    {
        if (this._IsFacingRight)
        {
            this._transform.localScale = new Vector2(4f, 4f);
        }
        else {
            this._transform.localScale = new Vector2(-4f, 4f);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("DeathPlan"))
        {
            //move the player's position to the spawn point's position
            this._transform.position = this.SpawnPoint.position;
            this.DeathSound.Play();
        }
        if (this.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            this.CoinSound.Play();
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            this._IsGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        this._IsGrounded = false;
    }
}
