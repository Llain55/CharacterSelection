using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public string playerName;
    public string playerClass;
    public int playerLevel;

    public float playerHealth;
    public float playerAttack;
    public float playerDefence;
    public float playerSpeed;
    public float playerIntelligence;
    public float playerCharisma;

    public string playerMentalState;
    public string playerWeakness;
    public string playerStrength;

    public int playerStrengthMultiplier;
    public int playerWeaknessMultiplier;

    public float mainAttackStrength;
    public float strongAttackStrength;
    private string[] powers;
    private void Start()
    {
        playerName = PlayerPrefs.GetString("playerName");
        playerClass = PlayerPrefs.GetString("playerClass");
        playerLevel = PlayerPrefs.GetInt("playerLevel");
        playerHealth = PlayerPrefs.GetFloat("playerHealth");
        playerAttack = PlayerPrefs.GetFloat("playerAttack");
        playerDefence = PlayerPrefs.GetFloat("playerDefence");
        playerSpeed = PlayerPrefs.GetFloat("playerSpeed");
        playerIntelligence = PlayerPrefs.GetFloat("playerIntelligence");
        playerCharisma = PlayerPrefs.GetFloat("PlayerCharisma");
        playerMentalState = PlayerPrefs.GetString("playerMentalState");
        playerWeakness = PlayerPrefs.GetString("playerWeakness");
        playerStrength = PlayerPrefs.GetString("playerStrength");
        playerStrengthMultiplier = PlayerPrefs.GetInt("playerStrengthMultiplier");
        playerWeaknessMultiplier = PlayerPrefs.GetInt("playerWeaknessMultiplier");

        mainAttackStrength = playerAttack;
        strongAttackStrength = playerAttack + playerIntelligence;
    }
}
