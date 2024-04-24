using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : Skill
{
    public override void UseSkill()
    {
        base.UseSkill();

        Debug.Log("스킬 사용");
    }
}
