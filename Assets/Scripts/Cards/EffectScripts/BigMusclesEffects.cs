using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMusclesEffects : CardEffectsBase
{
    public override void OnSelectionEffect()
    {
        PlayerStats.instance.attackDamage += 10;
    }
}
