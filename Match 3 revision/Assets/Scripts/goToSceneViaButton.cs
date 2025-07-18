using UnityEngine;
using UnityEngine.SceneManagement;
public class goToSceneViaButton : MonoBehaviour
{
    [SerializeField] string level; // The level to load when the button is pressed
    public void LoadScene()
    {
        SceneManager.LoadScene(level);
    }
}
