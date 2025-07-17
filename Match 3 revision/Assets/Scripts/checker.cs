using UnityEngine;

public class checker : MonoBehaviour
{
    checkerManager checkerManager;
    [SerializeField] bool thisIsSide1;
    
    private void OnTriggerEnter2D(Collider2D other)//check if a match 3 happens
    {
        checkerManager = transform.parent.GetComponent<checkerManager>();
        if (other.CompareTag("candy"))
        {
            if (thisIsSide1)
            {
                Debug.Log("Catch this nigga" + checkerManager.side1 + "with" + other.GetComponent<candy>().candyTypeIndex);
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
