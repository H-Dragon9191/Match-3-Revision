# Match 3 Revision

I started the project by outlining all the steps I had to do on papper and getting a game plan of the project

Step 1
the grid lauout group script was used to make the candies fall down(without animation as this just a prototype, though other aniimations were added)
Step 2
added the match 3 manager(stops the candies from falling down when not in the correct state)
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case gameState.waitingForInput:
            for (int i = 0; i < GridLayoutGroups.Length; i++)
            {
                GridLayoutGroups[i].enabled  = true;//Allowing Gravity
            }
            break;

            case gameState.AttemptingToSwitchCandies:
            for (int i = 0; i < GridLayoutGroups.Length; i++)
            {
                GridLayoutGroups[i].enabled  = false;//Pausing Gravity
            }
            break;
            case gameState.GettingPoints:
            for (int i = 0; i < GridLayoutGroups.Length; i++)
            {
                GridLayoutGroups[i].enabled  = false;//Pausing Gravity
            }
            break;
        }
    }
}
Step 3
I added a candy script that kept track of what type of candy it is and adds the appropriate skin
also added a candy spawner
(installed a purely art pack for the sprites as I'm not applying to be an artist)
I wrote
using UnityEngine;
using UnityEngine.UI;

public class candy : MonoBehaviour
{
    public int candyTypeIndex; 
    [SerializeField] Sprite[] Sprites;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        candyTypeIndex = Random.Range[0, Sprites.Length]; //Randomize The Candy
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Image>().sprite = Sprites[candyTypeIndex];
    }
}

and this spawner which automatically places the candy in the right hierchory position
using UnityEngine;

using UnityEngine;

public class candySpawner : MonoBehaviour
{
    [SerializeField] int yLevel;// as this is in the grid layout, we can check if it's y level goes under this one, then that means we should instantiate a new candy
    [SerializeField] GameObject candyPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= yLevel)
        {
            GameObject newCandy = Instantiate(candyPrefab);

            // Set the same parent as the current object, in order to be in the grid layout group
            Transform parent = transform.parent;
            newCandy.transform.SetParent(parent);

            //hierchory position
            int spawnerIndex = transform.GetSiblingIndex();
            newCandy.transform.SetSiblingIndex(spawnerIndex);
        }
    }
}

