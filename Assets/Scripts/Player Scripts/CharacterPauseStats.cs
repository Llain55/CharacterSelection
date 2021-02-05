using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPauseStats : MonoBehaviour
{
    [Header("UI Elements")]
    public Text charName;
    public Text charClass;
    public Text charHealth;
    public Text charAttack;
    public Text charDefence;
    public Text charSpeed;
    public Text charIntelligence;
    public Text charCharisma;
    public Text charMentalState;
    public Text charWeakness;
    public Text charStrength;

    void Start()
    {
        charName.text = PlayerPrefs.GetString("playerName");
        charClass.text = PlayerPrefs.GetString("playerClass");
        charHealth.text = PlayerPrefs.GetFloat("playerHealth").ToString();
        charAttack.text = PlayerPrefs.GetFloat("playerAttack").ToString();
        charDefence.text = PlayerPrefs.GetFloat("playerDefence").ToString();
        charSpeed.text = PlayerPrefs.GetFloat("playerSpeed").ToString();
        charIntelligence.text = PlayerPrefs.GetFloat("playerIntelligence").ToString();
        charCharisma.text = PlayerPrefs.GetFloat("PlayerCharisma").ToString();
        charMentalState.text = PlayerPrefs.GetString("playerMentalState");
        charWeakness.text = PlayerPrefs.GetString("playerWeakness");
        charStrength.text = PlayerPrefs.GetString("playerStrength");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
