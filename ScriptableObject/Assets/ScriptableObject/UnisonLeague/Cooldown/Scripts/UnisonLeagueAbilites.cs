using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New UL Ability", menuName = "UL Ability")]
public class UnisonLeagueAbilites : ScriptableObject
{
    [Header("Ability Informations")]
    public string abilityName = "Ability Name";
    public string abilityRank = "Ability Rank";
    public string abilityDescription = "Ability Description";
    public Texture2D abilitySprite;
    public enum abilityClass { Lancer, Soldier, Archer, Mage, Cleric }
    public abilityClass abilityclass;

    [Header("Ability Stats")]
    public float currentCooldown = 0;
    public float maxCooldown;

    public void PutOnCooldown()
    {
        CooldownManager.instance.StartCooldown(this);
    }

    public bool IsUnisonReady()
    {
        if (currentCooldown <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
