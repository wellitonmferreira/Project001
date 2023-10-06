using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour
{
    public string levelToLoad;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Player entered the trigger zone.");
            SceneManager.LoadScene("Level001"); // Certifique-se de que o nome da cena esteja correto.
        }
    }

}
