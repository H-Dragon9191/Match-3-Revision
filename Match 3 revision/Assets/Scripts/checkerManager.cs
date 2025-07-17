using UnityEngine;

public class checkerManager : MonoBehaviour
{
    [SerializeField] bool allSidesEqual;
    public candy[] candies;
    public int side1, side2 = 23290803;//random number so it doesnt auto think it is a match

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        candies[0] = transform.parent.GetComponent<candy>();//the actual candy for the checker
    }

    // Update is called once per frame
    void Update()
    {
        if (side1 == side2)
        {
            if (side1 == candies[0].candyTypeIndex)
            {
                allSidesEqual = true;
            }
        }
        if (allSidesEqual)
        {
            match3Manager.Instance.Match3(candies);
        }
    }
}
