using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationTrigger : MonoBehaviour
{
    private Enemy enemy => GetComponentInParent<Enemy>();
    private void AnimationTrigger()
    {
        enemy.AnimationTrigger();
    }

    private void AttackTrigger()
    {
        Collider2D[] coll = Physics2D.OverlapCircleAll(enemy.attackCheck.position, enemy.attackCheckRadius); // OverlaCircleAll - 범위안의 모든 콜라이더를 받아옴
        foreach (var hit in coll)
        {
            if (hit.GetComponent<Player>() != null)
                hit.GetComponent<Player>().Damage();
        }
    }
}
