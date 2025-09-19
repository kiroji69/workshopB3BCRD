using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator animator;



    public void LoadScene()
    {
        SceneManager.LoadScene("Level");
    }

    public void StartGame()
    {
        animator.SetBool("isPressed", true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
