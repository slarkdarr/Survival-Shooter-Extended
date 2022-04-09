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
    Text upgradeText;
    float upgradeDelayTime = 15f;

    // Start is called before the first frame update
    void Start()
    {
        diagonalAttack = GameObject.Find("DiagonalAttackButton").GetComponent<Button>();
        fasterAttack = GameObject.Find("FasterAttackButton").GetComponent<Button>();
        longerRange = GameObject.Find("LongerRangeButton").GetComponent<Button>();
        upgradeText = GameObject.Find("UpgradeText").GetComponent<Text>();

        diagonalAttack.onClick.AddListener(DABOnClick);
        fasterAttack.onClick.AddListener(FABOnClick);
        longerRange.onClick.AddListener(LARBOnClick);

        diagonalAttack.gameObject.SetActive(false);
        fasterAttack.gameObject.SetActive(false);
        longerRange.gameObject.SetActive(false);
        upgradeText.gameObject.SetActive(false);

        Debug.Log(upgradeDelayTime);
        InvokeRepeating("UpgradeWeapon", upgradeDelayTime, upgradeDelayTime);
    }

    void UpgradeWeapon()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        Time.timeScale = 0;

        diagonalAttack.gameObject.SetActive(true);
        fasterAttack.gameObject.SetActive(true);
        longerRange.gameObject.SetActive(true);
        upgradeText.gameObject.SetActive(true);

        if (playerShooting.diag >= playerShooting.maxdiag)
        {
            diagonalAttack.interactable = false;
        }

        if (playerShooting.timeBetweenBullets <= playerShooting.maxspeed)
        {
            fasterAttack.interactable = false;
        }

        if (playerShooting.range >= playerShooting.maxrange)
        {
            longerRange.interactable = false;
        }
    }

    void DABOnClick()
    {
        Debug.Log("DAB Clicked");
        playerShooting.addWeaponDiagonal();
        Debug.Log(playerShooting.diag);

        diagonalAttack.gameObject.SetActive(false);
        fasterAttack.gameObject.SetActive(false);
        longerRange.gameObject.SetActive(false);
        upgradeText.gameObject.SetActive(false);

        Time.timeScale = 1;
    }

    void FABOnClick()
    {
        Debug.Log("FAB Clicked");
        playerShooting.speedUpdater();
        Debug.Log(playerShooting.timeBetweenBullets);

        diagonalAttack.gameObject.SetActive(false);
        fasterAttack.gameObject.SetActive(false);
        longerRange.gameObject.SetActive(false);
        upgradeText.gameObject.SetActive(false);

        Time.timeScale = 1;
    }

    void LARBOnClick()
    {
        Debug.Log("LARB Clicked");
        playerShooting.rangeUpdater();
        Debug.Log(playerShooting.range);

        diagonalAttack.gameObject.SetActive(false);
        fasterAttack.gameObject.SetActive(false);
        longerRange.gameObject.SetActive(false);
        upgradeText.gameObject.SetActive(false);

        Time.timeScale = 1;
    }
}
