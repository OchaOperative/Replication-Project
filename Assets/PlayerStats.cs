using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds all the players statistics.
/// </summary>
public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    public float attackDamage;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Destroyed additional PlayerStats script!");
            Destroy(this);
        }
    }
}
