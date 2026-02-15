using UnityEngine;
using UnityEngine.SceneManagement;
public class RestaurtGame : MonoBehaviour, EventInterface
{
    public PlayerController playerr;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void OnInteract(PlayerController player)
    {
        playerr = player;
        RestartGame();
    }

    void RestartGame()
    {
        if (playerr != null) Destroy(playerr);
        SceneManager.LoadScene("LevelOne");
    }


}
