using UnityEngine;

public class scoreTracker : MonoBehaviour
{
    public int currentScore;
    public static scoreTracker Instance { get; private set; }//making this into a singleton
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("Duplicate scoreTracker destroyed.");
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
}
