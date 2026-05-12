using JetBrains.Annotations;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    Vector2 direction;
    private bool canJump = true;
    public float DashTime = 0.5f;
    private Rigidbody2D rigidbody2D;
    public float speed = 5;
    public float jumpForce = 5;
    public float maxSpeed = 10;
    public float stoppingForce = 10;
    public float Coin = 1;
    public CoinManager cm;
    private int _jumpcount = 0;
    private int _maxJumpCount = 2;
    public float DashForce = 10;
    private bool _IsDashing = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void FixedUpdate()

    {
        Playermovement();
        HandleMaxSpeed();
        PlayerStopping();
    }

    private void PlayerStopping()
    {
        if (direction.x == 0 && rigidbody2D.linearVelocityX != 0)
        {
            rigidbody2D.AddForce(new Vector2(-rigidbody2D.linearVelocityX * stoppingForce, 0));

        }
    }

    private void HandleMaxSpeed()
    {
        if (_IsDashing)
        {
            return;
        }
        if (rigidbody2D.linearVelocityX >= maxSpeed)
        {
            rigidbody2D.linearVelocityX = maxSpeed;
        }

        else if (rigidbody2D.linearVelocityX <= -maxSpeed)
        {
            rigidbody2D.linearVelocityX = -maxSpeed;
        }
    }

    private void Playermovement()
    {
        rigidbody2D.AddForce(new Vector2(direction.x, 0) * speed);
    }

    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }

    private void OnJump()
    {



        if (canJump)

        {

            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            _jumpcount++;
            if (_jumpcount >= _maxJumpCount)
            {
                canJump = false;
            }


        }
    }

    private void OnDash()
    {
        _IsDashing = true;
        rigidbody2D.AddForce(new Vector2(direction.x * DashForce, 0), ForceMode2D.Impulse);
        StartCoroutine(ResetDash(DashTime));

    }

    IEnumerator ResetDash(float timeToRest)
    {
        yield return new WaitForSeconds(timeToRest);
        _IsDashing = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
        _jumpcount = 0;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(0);
        if (other.gameObject.CompareTag("Coin"))
        {
            Debug.Log(1);
            cm.coinCount++;
            Destroy(other.gameObject);
        }
    }
  
}
    



