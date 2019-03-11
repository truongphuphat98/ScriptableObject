using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class ygoCard : ScriptableObject
{
    public new string characterName;
    public enum characterRace { Aqua, Beast, Dragon, Fish, Warrior, Spellcaster, Zombie }
    public characterRace characterrace;
    public string description;

    public Sprite artwork;

    public int Level;
    public int attack;
    public int defense;

    public void Print()
    {
        Debug.Log("The character name is " + characterName + ". " + "The Description: " + description + "The Creature Race: " + characterrace + " and also its level is " + Level + ". ");
    }
}
