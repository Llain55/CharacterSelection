using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CharacterSelection : MonoBehaviour
{
    [Header("Character Transforms")]
    public Transform archerTransform;
    public Transform bruteTransform;
    public Transform mageTransform;
    public Transform paladinTransform;

    [Header("Selection Variables")]
    public GameObject selectionLight;
    public GameObject container;
    public GameObject camera;

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

    [Header("Confirm Selection Elements")]
    public GameObject confirmScreen;
    public Text confirm;
    public Transform leftAnchor;
    public Transform rightAnchor;

    CharacterStats currentCharacter;

    int curChar;
    bool canSelect;
    bool cananimTo;
    bool canAnimFrom;
    public bool selectChar;
    // Start is called before the first frame update
    void Awake()
    {

        canSelect = true;
        cananimTo = true;
        canAnimFrom = false;
        selectChar = false;
        confirmScreen.SetActive(false);
        DisplayCharacterInfo(1);
        //container.transform.position = new Vector3(264f, -110f, 0);
        //container.transform.position = rightAnchor;
        selectionLight.transform.position = new Vector3(paladinTransform.transform.position.x, 76f, paladinTransform.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (canSelect)
        {
            Vector3 newPos;
            Vector3 oldPos = new Vector3(paladinTransform.transform.position.x, 76f, paladinTransform.transform.position.z); ;
            float time = 5f;
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (selectionLight.transform.position.x == archerTransform.transform.position.x)
                {
                    DisplayCharacterInfo(3);
                    selectionLight.transform.position = new Vector3(bruteTransform.transform.position.x, 89f, bruteTransform.transform.position.z);
                }
                else if (selectionLight.transform.position.x == bruteTransform.transform.position.x)
                {
                    DisplayCharacterInfo(2);
                    selectionLight.transform.position = new Vector3(mageTransform.transform.position.x, 91f, mageTransform.transform.position.z);
                }
                else if (selectionLight.transform.position.x == mageTransform.transform.position.x)
                {
                    DisplayCharacterInfo(1);
                    selectionLight.transform.position = new Vector3(paladinTransform.transform.position.x, 76f, paladinTransform.transform.position.z);
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (selectionLight.transform.position.x == paladinTransform.transform.position.x)
                {

                    DisplayCharacterInfo(2);
                    selectionLight.transform.position = new Vector3(mageTransform.position.x, 91f, mageTransform.position.z);
                }
                else if (selectionLight.transform.position.x == mageTransform.transform.position.x)
                {
                    DisplayCharacterInfo(3);
                    selectionLight.transform.position = new Vector3(bruteTransform.transform.position.x, 89f, bruteTransform.transform.position.z);
                }
                else if (selectionLight.transform.position.x == bruteTransform.transform.position.x)
                {

                    DisplayCharacterInfo(4);
                    selectionLight.transform.position = new Vector3(archerTransform.transform.position.x, 76f, archerTransform.transform.position.z);
                }
            }
        }



        if (cananimTo)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //cananimTo = false;
                canAnimFrom = true;
                confirmScreen.SetActive(true);
                if (!selectChar)
                {
                    confirm.text = "Would you like to start a new campaign with " + currentCharacter.name;
                    switch (currentCharacter.name)
                    {
                        case "Galdahir":
                            //confirm.text = "Would you like to start a new campaign with " + currentCharacter.name;
                            camera.GetComponent<Animation>().Play("ZoomToPaladin");
                            confirmScreen.transform.SetParent(rightAnchor);
                            confirmScreen.GetComponent<RectTransform>().localPosition = Vector2.zero;
                            confirmScreen.GetComponent<RectTransform>().pivot = new Vector2(1,0.5f);
                            mageTransform.gameObject.SetActive(false);
                            bruteTransform.gameObject.SetActive(false);
                            archerTransform.gameObject.SetActive(false);
                            selectChar = true;
                            canSelect = false;
                            break;
                        case "Dendra":
                            camera.GetComponent<Animation>().Play("ZoomToMage");
                            confirmScreen.transform.SetParent(rightAnchor);
                            confirmScreen.GetComponent<RectTransform>().localPosition = Vector2.zero;
                            confirmScreen.GetComponent<RectTransform>().pivot = new Vector2(1, 0.5f);
                            paladinTransform.gameObject.SetActive(false);
                            bruteTransform.gameObject.SetActive(false);
                            archerTransform.gameObject.SetActive(false);
                            selectChar = true;
                            canSelect = false;
                            break;
                        case "Delvin":
                            camera.GetComponent<Animation>().Play("ZoomToBrute");
                            confirmScreen.transform.SetParent(leftAnchor);
                            confirmScreen.GetComponent<RectTransform>().localPosition = Vector2.zero;
                            confirmScreen.GetComponent<RectTransform>().pivot = new Vector2(0, 0.5f);
                            paladinTransform.gameObject.SetActive(false);
                            mageTransform.gameObject.SetActive(false);
                            archerTransform.gameObject.SetActive(false);
                            selectChar = true;
                            canSelect = false;
                            break;
                        case "Elisa":
                            camera.GetComponent<Animation>().Play("ZoomToArcher");
                            confirmScreen.transform.SetParent(leftAnchor);
                            confirmScreen.GetComponent<RectTransform>().localPosition = Vector2.zero;
                            confirmScreen.GetComponent<RectTransform>().pivot = new Vector2(0, 0.5f);
                            paladinTransform.gameObject.SetActive(false);
                            mageTransform.gameObject.SetActive(false);
                            bruteTransform.gameObject.SetActive(false);
                            selectChar = true;
                            canSelect = false;
                            break;
                        default:
                            print("no character selected");
                            break;
                    }
                }
            }
            if (selectChar)
            {
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    PlayerPrefs.SetString("playerName", currentCharacter.name);
                    PlayerPrefs.SetString("playerClass", currentCharacter.className);
                    PlayerPrefs.SetInt("playerLevel", 1);
                    PlayerPrefs.SetFloat("playerHealth", currentCharacter.health);
                    PlayerPrefs.SetFloat("playerAttack", currentCharacter.attack);
                    PlayerPrefs.SetFloat("playerDefence", currentCharacter.defence);
                    PlayerPrefs.SetFloat("playerSpeed", currentCharacter.speed);
                    PlayerPrefs.SetFloat("playerIntelligence", currentCharacter.intelligence);
                    PlayerPrefs.SetFloat("playerCharisma", currentCharacter.charisma);
                    PlayerPrefs.SetString("playerMentalState", currentCharacter.mentalState);
                    PlayerPrefs.SetString("playerWeakness", currentCharacter.weakness);
                    PlayerPrefs.SetString("playerStrength", currentCharacter.strength);
                    PlayerPrefs.SetInt("playerWeaknessMultiplier", currentCharacter.weaknessMultiplier);
                    PlayerPrefs.SetInt("playerStrengthMultiplier", currentCharacter.strengthMultiplier);
                    canSelect = false;
                    selectChar = false;
                    confirmScreen.SetActive(false);
                    print("Character Selected. Starting game now...");
                    SceneManager.LoadScene("Tutorial Level");
                }
                else if (Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown(KeyCode.Escape))
                {
                    if (canAnimFrom)
                    {
                        canSelect = true;
                        canAnimFrom = false;
                        cananimTo = true;
                        selectChar = false;
                        paladinTransform.gameObject.SetActive(true);
                        mageTransform.gameObject.SetActive(true);
                        bruteTransform.gameObject.SetActive(true);
                        archerTransform.gameObject.SetActive(true);
                        confirmScreen.SetActive(false);
                        switch (currentCharacter.name)
                        {
                            case "Galdahir":
                                camera.GetComponent<Animation>().Play("ZoomFromPaladin");
                                break;
                            case "Dendra":
                                camera.GetComponent<Animation>().Play("ZoomFromMage");
                                break;
                            case "Delvin":
                                camera.GetComponent<Animation>().Play("ZoomFromBrute");
                                break;
                            case "Elisa":
                                camera.GetComponent<Animation>().Play("ZoomFromArcher");
                                break;
                            default:
                                break;
                        }

                    }
                }
            }
        }
    }


    public void DisplayCharacterInfo(int charNumber)
    {

        switch (charNumber)
        {
            case 1:
                currentCharacter = paladinTransform.GetComponent<CharacterStats>();
                print("Paladin Selected");
                charName.text = currentCharacter.name;
                charClass.text = currentCharacter.className;
                charHealth.text = currentCharacter.health.ToString();
                charAttack.text = currentCharacter.attack.ToString();
                charDefence.text = currentCharacter.defence.ToString();
                charSpeed.text = currentCharacter.speed.ToString();
                charIntelligence.text = currentCharacter.intelligence.ToString();
                charCharisma.text = currentCharacter.charisma.ToString();
                charMentalState.text = currentCharacter.mentalState;
                charWeakness.text = "x" + currentCharacter.weaknessMultiplier + " " + currentCharacter.weakness;
                charStrength.text = "x" + currentCharacter.strengthMultiplier + " " + currentCharacter.strength;
                //charStrengths.text = "Well balanced fighter. x2 defence against ranged and melee attacks." ;
                //charWeaknesses.text = "Weak to nature and shadow enemies. x2 damage taken from nature." ;
                break;
            case 2:
                currentCharacter = mageTransform.GetComponent<CharacterStats>();
                print("Mage Selected");
                charName.text = currentCharacter.name;
                charClass.text = currentCharacter.className;
                charHealth.text = currentCharacter.health.ToString();
                charAttack.text = currentCharacter.attack.ToString();
                charDefence.text = currentCharacter.defence.ToString();
                charSpeed.text = currentCharacter.speed.ToString();
                charIntelligence.text = currentCharacter.intelligence.ToString();
                charCharisma.text = currentCharacter.charisma.ToString();
                charMentalState.text = currentCharacter.mentalState;
                charWeakness.text = "x" + currentCharacter.weaknessMultiplier + " " + currentCharacter.weakness;
                charStrength.text ="x" + currentCharacter.strengthMultiplier + " " + currentCharacter.strength;
                //charStrengths.text = "Very high magical damage. x2 damage to shadow enemies.";
                //charWeaknesses.text = "Weak to melee attacks. x2 damage taken from light enemies.";
                break;
            case 3:
                currentCharacter = bruteTransform.GetComponent<CharacterStats>();
                print("Brute Selected");
                charName.text = currentCharacter.name;
                charClass.text = currentCharacter.className;
                charHealth.text = currentCharacter.health.ToString();
                charAttack.text = currentCharacter.attack.ToString();
                charDefence.text = currentCharacter.defence.ToString();
                charSpeed.text = currentCharacter.speed.ToString();
                charIntelligence.text = currentCharacter.intelligence.ToString();
                charCharisma.text = currentCharacter.charisma.ToString();
                charMentalState.text = currentCharacter.mentalState;
                charWeakness.text = "x" + currentCharacter.weaknessMultiplier + " " + currentCharacter.weakness;
                charStrength.text = "x" + currentCharacter.strengthMultiplier + " " + currentCharacter.strength;
                //charStrengths.text = "High physical defence. x2 defence against melee attacks.";
                //charWeaknesses.text = "Takes x2 magical damage. Weak to shadow enemies.";
                break;
            case 4:
                currentCharacter = archerTransform.GetComponent<CharacterStats>();
                print("Archer Selected");
                charName.text = currentCharacter.name;
                charClass.text = currentCharacter.className;
                charHealth.text = currentCharacter.health.ToString();
                charAttack.text = currentCharacter.attack.ToString();
                charDefence.text = currentCharacter.defence.ToString();
                charSpeed.text = currentCharacter.speed.ToString();
                charIntelligence.text = currentCharacter.intelligence.ToString();
                charCharisma.text = currentCharacter.charisma.ToString();
                charMentalState.text = currentCharacter.mentalState;
                charWeakness.text = "x" + currentCharacter.weaknessMultiplier + " " + currentCharacter.weakness;
                charStrength.text = "x" + currentCharacter.strengthMultiplier + " " + currentCharacter.strength;
                //charStrengths.text = "Ranged DPS, x2 damage to nature and airborne enemies.";
                //charWeaknesses.text = "Take x2 damage from melee and magic attacks.";
                break;
            default:
                print("no character selected...");
                break;
        }
    }
}
