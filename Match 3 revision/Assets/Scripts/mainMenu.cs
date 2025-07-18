using UnityEngine;
using UnityEngine.SceneManagement;
public class mainMenu : MonoBehaviour
{
    public void Play(int level)
    {
        SceneManager.LoadScene("Level_" + level);
    }
}
