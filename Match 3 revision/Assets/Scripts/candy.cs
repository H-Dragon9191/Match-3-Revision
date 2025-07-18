using UnityEngine;
using UnityEngine.UI;

public class candy : MonoBehaviour
{
    public int candyTypeIndex;
    [SerializeField] Sprite[] Sprites;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        candyTypeIndex = Random.Range(0, Sprites.Length); //Randomize The Candy
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).GetComponent<Image>().sprite = Sprites[candyTypeIndex];
    }
    void beSucessfullTrue()
    {
        match3Manager.Instance.succesfull = true;
    }

    void beSucessfullFalse()
    {
        match3Manager.Instance.succesfull = false;
    }
    void beGettingPointsState()
    {
        match3Manager.Instance.currentState = match3Manager.gameState.GettingPoints;
    }
    void beWaitingForInputState()
    {
        match3Manager.Instance.currentState = match3Manager.gameState.waitingForInput;
    }
}
