using UnityEngine;
using UnityEngine.UI;

public class match3Manager : MonoBehaviour
{
    [SerializeField] GridLayoutGroup[] GridLayoutGroups;
    public enum gameState
    {
        waitingForInput,
        AttemptingToSwitchCandies,//may or may not be succesfull
        GettingPoints
    }

    public gameState currentState;
    public static match3Manager Instance { get; private set; }//making this into a singleton
    private GameObject startObject;
    private GameObject endObject;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("Duplicate Match3Manager destroyed.");
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }


    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case gameState.waitingForInput:
                for (int i = 0; i < GridLayoutGroups.Length; i++)
                {
                    GridLayoutGroups[i].enabled = true;//Allowing Gravity
                                                       // Start touch/click
                    if (Input.GetMouseButtonDown(0))
                    {
                        startObject = GetObjectUnderFinger();
                    }

                    // Finger/mouse moving
                    if (Input.GetMouseButton(0))
                    {
                        GameObject currentObject = GetObjectUnderFinger();

                        if (startObject != null && currentObject != null && currentObject != startObject)
                        {
                            endObject = currentObject;
                            Debug.Log("Swiped from " + startObject.name + " to " + endObject.name);

                            // Do something with the swipe...
                            moveTwoCandies(startObject, endObject);
                            // Reset after swipe is detected
                            startObject = null;
                            endObject = null;
                        }
                    }
                }
                break;

            case gameState.AttemptingToSwitchCandies:
                for (int i = 0; i < GridLayoutGroups.Length; i++)
                {
                    GridLayoutGroups[i].enabled = false;//Pausing Gravity
                }
                break;
            case gameState.GettingPoints:
                for (int i = 0; i < GridLayoutGroups.Length; i++)
                {
                    GridLayoutGroups[i].enabled = false;//Pausing Gravity
                }
                break;
        }
    }

    public void Match3(candy[] candies)
    {
        Debug.Log("match 3 with" + candies[0].name + candies[1].name + candies[2].name);
        for (int i = 0; i < candies.Length; i++)
        {
            candies[i].transform.GetComponent<Animator>().SetTrigger("collectingAnimation");
        }
    }

    GameObject GetObjectUnderFinger()
    {
        Vector2 screenPos = Input.mousePosition;
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);
        if (hit.collider2D != null)
        {
            return hit.collider2D.gameObject;
        }
        return null;
    }
    void moveTwoCandies(GameObject candy_1, GameObject candy_2)
    {
        Debug.Log("moved meine nigga");
    }
}
