using TMPro;
using UnityEngine;

public class S_CollectManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int nowtCollect = 0;
    public int totalCollect = 0;
    public GameObject door;
    public AudioClip escapesound;
    public GameObject player;

    public TextMeshProUGUI collectText;
    bool hasPlayedSound = false;

    private void Start()
    {
        S_Collectible[] collectibles = FindObjectsByType<S_Collectible>(FindObjectsSortMode.None);
        totalCollect = collectibles.Length;

        nowtCollect = 0;
        UpdateUI();

    }

    void Update()
    {

        if (nowtCollect >= totalCollect)
        {
            door.SetActive(true);
            if (!hasPlayedSound)
            {
                AudioSource.PlayClipAtPoint(escapesound, player.transform.position);
                hasPlayedSound = true;
            }    
            
        }

    }

    public void AddCollect()
    {

        nowtCollect++;
        UpdateUI();


        if (nowtCollect >= totalCollect)
        {
            collectText.text = "Go Find Door And Escape!!!";


        }

    }

    public void UpdateUI()
    {
        if (collectText != null)
        {
            collectText.text = "Collected: " + nowtCollect + " / " + totalCollect;
        }
    }

}
