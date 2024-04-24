using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSkill : Skill
{
    [SerializeField] private GameObject clonePrefabs;
    [SerializeField] private float cloneDuration;
    [Space]
    [SerializeField] private bool canAttack;
    private GameObject newClone;

    public void CreateClone(Transform _clonePosition)
    {
        if (CanUseSkill())
            newClone.GetComponent<CloneSkillController>().SetUpClone(_clonePosition, cloneDuration, canAttack);
    }

    public override bool CanUseSkill()
    {
        return base.CanUseSkill();
    }

    public override void UseSkill()
    {
        base.UseSkill();

        newClone = Instantiate(clonePrefabs);
    }
}
