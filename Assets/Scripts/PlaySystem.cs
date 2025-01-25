using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySystem : MonoBehaviour
{
    public TMPro.TMP_Text mechanic;
    public TMPro.TMP_Text scientiest;
    public TMPro.TMP_Text gunslinger;
    public TMPro.TMP_Text secondDriver;

    public int loyalMechanic;
    public int loyalGunslinger;
    public int loyalSecondDriver;
    public int loyalScientiest;

    public List<GameObject> choices = new List<GameObject>();
    int current;

    public List<int> sabotage = new List<int>() { 0, 1, 2, 3, 4};
    int currentSabotage;

    public Transform choicesTransform;

    public GameObject gunslingerEnding;
    public GameObject scientiestEnding;
    public GameObject mechanicEnding;
    public GameObject secondDriverEnding;
    
    void Update()
    { 
        //choices[current].transform.position = choicesTransform.position;
        DeadLoyalty();
        Loyalty();
    }

    public void Dead()
    {
        SceneManager.LoadScene(4);
    }

    void DeadLoyalty()
    {
        if (loyalGunslinger < 0)
        {
            BadGunslinger();
        }
        if (loyalMechanic < 1)
        {
            BadMechanic();
        }
        if (loyalScientiest < 1)
        {
            BadScientiest();
        }
        if (loyalSecondDriver < 1)
        {
            BadSecondDriver();
        }
    }

    void BadMechanic()
    {
        mechanicEnding.SetActive(true);
    }
    void BadGunslinger()
    {
        gunslingerEnding.SetActive(true);
    }
    void BadScientiest()
    {
        scientiestEnding.SetActive(true);
    }
    void BadSecondDriver()
    {
        secondDriverEnding.SetActive(true);
    }

    void Loyalty()
    {
        mechanic.text = "Ìåõ.: " + loyalMechanic.ToString();
        scientiest.text = "Ó÷.: " + loyalScientiest.ToString();
        gunslinger.text = "Îð.: " + loyalGunslinger.ToString();
        secondDriver.text = "Âò.Ï.: " + loyalSecondDriver.ToString();
        if (loyalGunslinger > 99) loyalGunslinger = 100;
        if (loyalMechanic > 99) loyalMechanic = 100;
        if (loyalScientiest > 99) loyalScientiest = 100;
        if (loyalSecondDriver > 99) loyalSecondDriver = 100;
    }
    public void UpdateButtonGood()
    {
        loyalGunslinger += cards.GetComponent<CardboardText>().gunslingerScore;
        loyalMechanic += cards.GetComponent<CardboardText>().mechanic;
        loyalScientiest += cards.GetComponent<CardboardText>().scientistScore;
        loyalSecondDriver += cards.GetComponent<CardboardText>().secondDriver;
        Destroy(cards);
        DayChange.localCounts--;
    }
    GameObject cards;
    public void UpdateButtonBad()
    {
        loyalGunslinger -= cards.GetComponent<CardboardText>().gunslingerScore;
        loyalMechanic -= cards.GetComponent<CardboardText>().mechanic;
        loyalScientiest -= cards.GetComponent<CardboardText>().scientistScore;
        loyalSecondDriver -= cards.GetComponent<CardboardText>().secondDriver;
        Destroy(cards);
        DayChange.localCounts--;
    }

    public void UpdateButton()
    {
        current = Random.Range(0, choices.Count);
        GameObject clone = Instantiate(choices[current]);
        cards = clone;
    }
}
