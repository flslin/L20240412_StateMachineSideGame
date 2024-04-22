using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTrigger : MonoBehaviour
{
    private Player player => GetComponentInParent<Player>();
    private void AnimationTrigger()
    {
        player.AnimationTrigger();
    }

    private void AttackTrigger()
    {
        Collider2D[] coll = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackCheckRadius); // OverlaCircleAll - 범위안의 모든 콜라이더를 받아옴
        foreach(var hit in coll)
        {
            if (hit.GetComponent<Enemy>() != null)
                hit.GetComponent<Enemy>().Damage();
        }
    }
}
