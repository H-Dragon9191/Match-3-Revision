using UnityEngine;

public class addScore : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void addingScore()
    {
        Debug.Log("Yo nigga score is increased!");
        Destroy(this.gameObject);
    }
}
