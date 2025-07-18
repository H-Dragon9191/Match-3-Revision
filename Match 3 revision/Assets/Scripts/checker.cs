using UnityEngine;

public class checker : MonoBehaviour
{
    checkerManager checkerManager;
    [SerializeField] bool thisIsSide1;
    
    private void OnTriggerEnter2D(Collider2D other)//check if a match 3 happens
    {
        checkerManager = transform.parent.GetComponent<checkerManager>();
        //check if it is a dupelicate
        for (int i = 0; i < checkerManager.candies.Length; i++)
        {
            if(checkerManager.candies[i] == other.gameObject.GetComponent<candy>())
            return;
        }
        if (other.CompareTag("candy") && match3Manager.Instance.currentState == match3Manager.gameState.waitingForInput)
        {
            if (thisIsSide1)
            {
                checkerManager.side1 = other.GetComponent<candy>().candyTypeIndex;
                checkerManager.candies[1] = other.GetComponent<candy>();
            }
            else
            {
                checkerManager.side2 = other.GetComponent<candy>().candyTypeIndex;
                checkerManager.candies[2] = other.GetComponent<candy>();
            }
        }
    }
}
