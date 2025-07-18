using UnityEngine;

public class unlockLevel : MonoBehaviour
{
    [SerializeField] string levelYouWant; // The level to unlock
    [SerializeField] int scoreNeeded; // The score needed to unlock the level
    [SerializeField] GameObject unlocked; // The UI element to show when the level is unlocked
    [SerializeField] GameObject locked; // The UI element to show when the level is
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Score" + levelYouWant) >= scoreNeeded)
        {
            unlocked.SetActive(true);
            locked.SetActive(false);
        }
        else
        {
            unlocked.SetActive(false);
            locked.SetActive(true);
        }
    }
}
