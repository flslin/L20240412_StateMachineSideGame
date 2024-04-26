using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordSkillController : Skill
{
    private Animator anim;
    private Rigidbody2D rb;
    private CircleCollider2D cd;
    private Collider2D enemyCollider;
    private Enemy_Skeleton es;

    private bool isReturn = true;
    private bool isGround = false;
    private bool isAlive = true;
    private int hit = 0;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<CircleCollider2D>();
        es = GetComponent<Enemy_Skeleton>();

        SwordAnim();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        if (!isReturn)
        {
            if (enemy.facingDir == 1)
            {
                transform.position = new Vector3(enemyCollider.transform.position.x + 0.6f, enemyCollider.transform.position.y + 0.01f, enemyCollider.transform.position.z);
                transform.rotation = Quaternion.Euler(0, 0, -25);
            }
            else
            {
                transform.position = new Vector3(enemyCollider.transform.position.x - 0.6f, enemyCollider.transform.position.y + 0.01f, enemyCollider.transform.position.z);
                transform.rotation = Quaternion.Euler(0, 180, -25);
            }
        }
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
            hit++;
            collision.GetComponent<Enemy>().Damage();
            anim.SetBool("rotation", false);
            enemyCollider = collision;
            isReturn = false;
            isAlive = false;
            Invoke("DestorySword", 5f);
        }

        if (collision.CompareTag("Ground"))
        {
            anim.SetBool("rotation", false);
            rb.velocity = new Vector2(0, 0);
            rb.gravityScale = 0;
            isGround = true;
            if (collision.CompareTag("Player"))
            {
                Destroy(gameObject);
                // 공격 가능
            }
            Invoke("DestorySword", 3f);
        }

        if (hit >= 3)
            Dead();
        //gameObject.SetActive(false);
    }

    IEnumerator Dead()
    {
        es.stateMachine.ChangeState(es.deadState);

        yield return new WaitForSeconds(1);

        if (gameObject.CompareTag("Enemy") && !isAlive)
        {
            enemy.gameObject.SetActive(false);
        }
    }

    //private void ReturnSword()
    //{
    //    Vector2 moveToPlayer = new Vector2(AimDirection().normalized.x * transform.position.x, AimDirection().normalized.y);
    //}

    private void DestorySword()
    {
        Destroy(gameObject);
    }

    //public Vector2 AimDirection()
    //{
    //    Vector2 playerPosition = player.transform.position;
    //    Vector2 enemyPosition = enemy.transform.position;

    //    Vector2 direction = playerPosition - enemyPosition;

    //    return direction;
    //}
}
