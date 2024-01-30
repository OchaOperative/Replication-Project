using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu]
public class CardInformation : ScriptableObject
{
    public enum CardTypes
    {
        Weapon,
        Buff,
        Effect,
    }

    [Header("Visuals")]
    public CardTypes CardType;
    public Sprite icon;

    [Header("Text")]
    public string flavourText;
    public string cardDescription;     
}
