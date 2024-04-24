using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSkill : Skill
{
    [SerializeField] private GameObject clonePrefabs;

    public void CreateClone(Transform _clonePosition)
    {
        GameObject newClone = Instantiate(clonePrefabs);

        newClone.GetComponent<CloneSkillController>().SetUpClone(_clonePosition);
    }
}
