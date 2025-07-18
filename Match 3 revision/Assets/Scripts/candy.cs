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
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);//dk why but it changes the sizes so we do this to keep it constant
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
