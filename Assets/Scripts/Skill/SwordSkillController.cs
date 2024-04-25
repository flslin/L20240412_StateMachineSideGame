using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSkillController : Skill
{
    private Animator anim;
    private Rigidbody2D rb;
    private CircleCollider2D cd;
    private GameObject enemy;
        Collider2D enemyCollider;

    private bool isReturn = true;
    private bool isGround = false;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<CircleCollider2D>();
        enemy = GetComponent<GameObject>();

        SwordAnim();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        if (!isReturn)
            transform.position = enemyCollider.transform.position;        
    }

    public void SetupSword(Vector2 _dir, float _gravityScale)
    {
        rb.velocity = _dir;
        rb.gravityScale = _gravityScale;
    }

    public void SwordAnim()
    {
        anim.SetBool("rotation", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && isReturn && !isGround)
        {
            collision.GetComponent<Enemy>().Damage();
            anim.SetBool("rotation", false);
            enemyCollider = collision;
            isReturn = false;
            Invoke("DestorySword", 5f);
        }

        if (collision.CompareTag("Ground"))
        {
            anim.SetBool("rotation", false);
            rb.velocity = new Vector2(0, 0);
            rb.gravityScale = 0;
            isGround = true;
            Invoke("DestorySword", 5f);
        }
    }

    private void ReturnSword()
    {

    }

    private void DestorySword()
    {
        Destroy(gameObject);
    }
}
