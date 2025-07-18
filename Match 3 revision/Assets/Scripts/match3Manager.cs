using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
 
public class match3Manager : MonoBehaviour
{
    [SerializeField] float distance = 300f; //distance to switch candies, if this was not made, then we could switch any two candies
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
    public bool succesfull;
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

    GraphicRaycaster raycaster;
    public EventSystem eventSystem;

    PointerEventData pointerData;
    List<RaycastResult> results = new List<RaycastResult>();
    [SerializeField] float duration  = 2;//duration of switching
    Transform firstTouchedCandy, secondTouchedCandy;
    void Start()
    {
        raycaster = gameObject.GetComponent<GraphicRaycaster>();
    }
    void Update()
    {
        switch (currentState)
        {
            case gameState.waitingForInput:
                for (int i = 0; i < GridLayoutGroups.Length; i++)
                {
                    GridLayoutGroups[i].enabled = true;//Allowing Gravity
                                                       // Start touch/click
                    if (Input.GetMouseButtonDown(0)) // Or use touch
                    {
                        pointerData = new PointerEventData(eventSystem);
                        pointerData.position = Input.mousePosition;

                        results.Clear();
                        raycaster.Raycast(pointerData, results);

                        foreach (RaycastResult result in results)
                        {
                            if (result.gameObject.transform.parent.GetComponent<candy>() == null)//not candy
                            {
                                continue;
                            }
                            firstTouchedCandy = result.gameObject.transform.parent;
                            // You can check tags or names here
                        }
                    }
                    if (Input.GetMouseButtonUp(0)) // Or use touch
                    {
                        pointerData = new PointerEventData(eventSystem);
                        pointerData.position = Input.mousePosition;

                        results.Clear();
                        raycaster.Raycast(pointerData, results);

                        foreach (RaycastResult result in results)
                        {
                            if (result.gameObject.transform.parent.GetComponent<candy>() == null)//not candy
                            {
                                continue;
                            }

                            secondTouchedCandy = result.gameObject.transform.parent;

                            // You can check tags or names here
                            float distance_ = Vector3.Distance(firstTouchedCandy.position, secondTouchedCandy.position);
                            if(distance_ > distance) return;
                            StartCoroutine(moveTwoCandies(firstTouchedCandy, secondTouchedCandy, false));
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
        for (int i = 0; i < candies.Length; i++)
        {
            candies[i].transform.GetComponent<Animator>().SetTrigger("collectingAnimation");
        }
    }

    IEnumerator moveTwoCandies(Transform candy_1, Transform candy_2, bool undo)
    {
        currentState = gameState.AttemptingToSwitchCandies;

        Vector3 startA = candy_1.position;
        Vector3 startB = candy_2.position;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            candy_1.position = Vector3.Lerp(startA, startB, t);
            candy_2.position = Vector3.Lerp(startB, startA, t);

            yield return null;
        }

        candy_1.position = startB;
        candy_2.position = startA;
        //we are undoing so no need to check if it is succesfull
        if (!succesfull && !undo)
        {
            StartCoroutine(moveTwoCandies(candy_1, candy_2, true));
            yield return null;
        }
        else if(undo)
        {
            currentState = gameState.waitingForInput;
        }
    }
}
