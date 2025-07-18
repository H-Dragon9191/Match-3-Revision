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
        if (transform.position.y <= yLevel && match3Manager.Instance.currentState == match3Manager.gameState.waitingForInput)
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
