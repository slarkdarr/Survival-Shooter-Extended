using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUpgradeManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PlayerShooting playerShooting;

    Button diagonalAttack;
    Button fasterAttack;
    Button longerRange;
    Button closeButton;
    Text upgradeText;
    Text maxDiagonalAtkText;
    Text maxAtkSpeedText;
    Text maxAtkRangeText;
    float upgradeDelayTime = 15f;

    // Start is called before the first frame update
    void Start()
    {
        diagonalAttack = GameObject.Find("DiagonalAttackButton").GetComponent<Button>();
        fasterAttack = GameObject.Find("FasterAttackButton").GetComponent<Button>();
        longerRange = GameObject.Find("LongerRangeButton").GetComponent<Button>();
        closeButton = GameObject.Find("CloseButton").GetComponent<Button>();
        upgradeText = GameObject.Find("UpgradeText").GetComponent<Text>();
        maxDiagonalAtkText = GameObject.Find("MaxDiagonalAttackText").GetComponent<Text>();
        maxAtkSpeedText = GameObject.Find("MaxAttackSpeedText").GetComponent<Text>();
        maxAtkRangeText = GameObject.Find("MaxAttackRangeText").GetComponent<Text>();

        // listener functions for the buttons
        diagonalAttack.onClick.AddListener(DABOnClick);
        fasterAttack.onClick.AddListener(FABOnClick);
        longerRange.onClick.AddListener(LARBOnClick);
        closeButton.onClick.AddListener(CloseOnClick);

        // hide buttons initially
        diagonalAttack.gameObject.SetActive(false);
        fasterAttack.gameObject.SetActive(false);
        longerRange.gameObject.SetActive(false);
        upgradeText.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);
        maxDiagonalAtkText.gameObject.SetActive(false);
        maxAtkSpeedText.gameObject.SetActive(false);
        maxAtkRangeText.gameObject.SetActive(false);

        // show weapon upgrade every 15 seconds
        InvokeRepeating("UpgradeWeapon", upgradeDelayTime, upgradeDelayTime);
    }

    void UpgradeWeapon()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        // pause the game
        Time.timeScale = 0;

        // show buttons
        diagonalAttack.gameObject.SetActive(true);
        fasterAttack.gameObject.SetActive(true);
        longerRange.gameObject.SetActive(true);
        upgradeText.gameObject.SetActive(true);
        closeButton.gameObject.SetActive(true);
    }

    // Diagonal Attack Button
    void DABOnClick()
    {
        Debug.Log("DAB Clicked");
        playerShooting.addWeaponDiagonal();

        // set button to uninteractable if the diagonal value is higher or equal to max diagonal value
        if (playerShooting.diag >= playerShooting.maxdiag)
        {
            diagonalAttack.interactable = false;
            maxDiagonalAtkText.gameObject.SetActive(true);
        }

        Debug.Log(playerShooting.diag);

        // hide the buttons
        diagonalAttack.gameObject.SetActive(false);
        fasterAttack.gameObject.SetActive(false);
        longerRange.gameObject.SetActive(false);
        upgradeText.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);

        // resume the game
        Time.timeScale = 1;
    }

    // Faster Attack Button
    void FABOnClick()
    {
        Debug.Log("FAB Clicked");
        playerShooting.speedUpdater();

        // set button to uninteractable if the attack speed value is lower or equal to max attack speed value
        if (playerShooting.timeBetweenBullets <= playerShooting.maxspeed)
        {
            fasterAttack.interactable = false;
            playerShooting.timeBetweenBullets = playerShooting.maxspeed;
            maxAtkSpeedText.gameObject.SetActive(true);
        }

        Debug.Log(playerShooting.timeBetweenBullets);

        // hide the buttons
        diagonalAttack.gameObject.SetActive(false);
        fasterAttack.gameObject.SetActive(false);
        longerRange.gameObject.SetActive(false);
        upgradeText.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);

        // resume the game
        Time.timeScale = 1;
    }

    // Longer Attack Range Button
    void LARBOnClick()
    {
        Debug.Log("LARB Clicked");
        playerShooting.rangeUpdater();

        // set button to uninteractable if the shooting range value is higher or equal to max shooting range value
        if (playerShooting.range >= playerShooting.maxrange)
        {
            longerRange.interactable = false;
            playerShooting.range = playerShooting.maxrange;
            maxAtkRangeText.gameObject.SetActive(true);
        }

        Debug.Log(playerShooting.range);


        // hide the buttons
        diagonalAttack.gameObject.SetActive(false);
        fasterAttack.gameObject.SetActive(false);
        longerRange.gameObject.SetActive(false);
        upgradeText.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);

        // resume the game
        Time.timeScale = 1;
    }

    void CloseOnClick()
    {
        Debug.Log("Close Button Clicked");

        // hide the buttons
        diagonalAttack.gameObject.SetActive(false);
        fasterAttack.gameObject.SetActive(false);
        longerRange.gameObject.SetActive(false);
        upgradeText.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);

        // resume the game
        Time.timeScale = 1;
    }
}
