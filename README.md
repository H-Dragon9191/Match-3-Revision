# Match 3 Revision

I started the project by outlining all the steps I had to do on papper and getting a game plan of the project

Step 1
the grid lauout group script was used to make the candies fall down(without animation as this just a prototype, though other animations were added)
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
Step 4
I kind off just got into the zone here, so I didn't document too much but I think that's fine as you guys asked only for a brief read me and this is already too long
all of the scripts are in scripts folder, if you wish to review them

Closing notes
The code is highly scallable, with ways to add more abilities and candy types
the bugs are few in the game(though their is one, where when moving candies and getting points make it move a bit weirdly, I tried to fix that but had no time due to a reason I will state in a bit)

Overall, It took me about 8 hours, but I would have done it in a lesser amount of days but I barely had any time(even now) because We have been repainting the house and now redecorating 

If I had more time I would've added a special type of candy that destorys everything in a row or collumn, added sound effects(other than the jazz that I played on the piano) and lastly fixed that bug, that doesn't ruin gameplay but makes it differnt

Evaluation For Junior
Working Match 3 game (done, with minor bugs)
Mobile Friendly UI and controls(done)
Basic Progression b/w levels(done and extra as it use the highscore system)
clean code(done as there were many comments to explain difffernt parts)

Evaluation For Senior
Reuseablity(some components have this ability like the candy script works for all the candies and can even work for special ones)
Mobile optimization(runs well on mobile)
smooth animation(some animations were implemented and run smoothly)
code extensibility for future use(done)

Stretch Goals
Visiual effect for matches
Music but no sound effects