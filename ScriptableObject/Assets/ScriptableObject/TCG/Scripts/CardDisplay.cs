using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public ygoCard card;

    [Header("Card Database")]
    public Text nameText;
    public Text raceText;
    public Text descriptionText;

    [Header("Card Artwork")]
    public Image artworkImage;

    [Header("Card Attributes")]
    public Text levelText;
    public Text attackText;
    public Text defenseText;

    void Start()
    {
        DisplayDetails();
    }

    void Update()
    {
        if(InputManager.instance.GetKey("Interact"))
        {
            DisplayDetails();
        }
    }

    public void DisplayDetails()
    {
        card.Print();

        nameText.text = card.name;
        raceText.text = "Race: " + card.characterrace.ToString();
        descriptionText.text = card.description;

        artworkImage.sprite = card.artwork;

        levelText.text = card.Level.ToString();
        attackText.text = card.attack.ToString();
        defenseText.text = card.defense.ToString();
    }
}
