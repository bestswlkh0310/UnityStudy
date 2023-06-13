using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    #region Field
    
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    
    public Vector2 downCastSize = new (1.0f, 0.05f);
    public float downCastMaxDistance = 1.05f;
    
    public Vector2 sideCastSize = new (0.05f, 1.0f);
    public float sideCastMaxDistance = 0.72f;
    
    public Vector2 upCastSize = new (0.05f, 1.0f);
    public float upCastMaxDistance = 0.72f;

    #endregion

    #region Controller

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        Jump();
        DownOnCeiling();
    }

    private void Move()
    {
        var xInput = Input.GetAxisRaw("Horizontal");
        var move = new Vector3(xInput, 0.0f, 0.0f);

        if (xInput < 0.0f)
        {
            _spriteRenderer.flipX = true;
        } else if (xInput != 0.0f)
        {
            _spriteRenderer.flipX = false;
        }
        
        if ((!IsOnRightSide() && xInput > 0.0f) || (!IsOnLeftSide() && xInput < 0.0f))
        {
            transform.Translate(move * Time.deltaTime * speed);
        }
    }

    private void Jump()
    {
        if (IsOnGround() && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector2.up * jumpForce);
        }
    }

    private bool IsOnRightSide()
    {
        RaycastHit2D raycastHitRight = Physics2D.BoxCast(
            transform.position, sideCastSize,
            0f, Vector2.right,
            sideCastMaxDistance,
            LayerMask.GetMask("Ground")
        );
        
        return raycastHitRight.collider != null;
    }
    
    private bool IsOnLeftSide()
    {
        RaycastHit2D raycastHitLeft = Physics2D.BoxCast(
            transform.position, sideCastSize, 
            0f, Vector2.left,
            sideCastMaxDistance,
            LayerMask.GetMask("Ground")
        );
        return raycastHitLeft.collider != null;
    }


    private bool IsOnGround()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(
            transform.position,
            downCastSize, 
            0f, 
            Vector2.down, 
            downCastMaxDistance,
            LayerMask.GetMask("Ground")
        );
        
        return raycastHit.collider != null;
    }

    private void DownOnCeiling()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(
            transform.position,
            upCastSize, 
            0f, 
            Vector2.up,
            upCastMaxDistance,
            LayerMask.GetMask("Ground")
        );
        
        if (raycastHit.collider != null)
        {
            Debug.Log("asdasd");
            Debug.Log(raycastHit.point);
            _rb.velocity = new Vector2(_rb.velocity.x, 0.0f);
            transform.position = new Vector3(transform.position.x, raycastHit.point.y - 0.35f, transform.position.z);
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawRay(transform.position, Vector2.right * sideCastMaxDistance);
        Gizmos.DrawWireCube(transform.position + Vector3.right * sideCastMaxDistance, sideCastSize);

        Gizmos.DrawRay(transform.position, Vector2.down * downCastMaxDistance);
        Gizmos.DrawWireCube(transform.position + Vector3.down * downCastMaxDistance, downCastSize);

        Gizmos.DrawRay(transform.position, Vector2.left * sideCastMaxDistance);
        Gizmos.DrawWireCube(transform.position + Vector3.left * sideCastMaxDistance, sideCastSize);
        
        Gizmos.DrawRay(transform.position, Vector2.up * upCastMaxDistance);
        Gizmos.DrawWireCube(transform.position + Vector3.up * upCastMaxDistance, upCastSize);
    }
    
    #endregion Controller

    #region Event

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Spike"))
        {
            Debug.Log(other.transform.tag + "와 충돌");
            PlayerStats.Instance.TakeDamage(1);
        }
    }

    #endregion
    
    #region Animation



    #endregion
    
}