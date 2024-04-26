using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField] protected float cooldown;
    protected float cooldownTimer;

    protected Player player;
    protected Enemy enemy;

    protected virtual void Start()
    {
        player = PlayerManager.instance.player;
        enemy = EnemyManager.instance.enemy;
    }

    protected virtual void Update()
    {
        cooldownTimer -= Time.deltaTime;
    }

    public virtual bool CanUseSkill()
    {
        if(cooldownTimer <= 0)
        {
            UseSkill();
            cooldownTimer = cooldown;
            return true;
        }

        Debug.Log("cooldown");
        return false;
    }

    public virtual void UseSkill()
    {
        // ��� �� ��ų ����
    }
}
