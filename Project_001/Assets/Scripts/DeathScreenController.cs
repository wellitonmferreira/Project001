using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreenController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject respawnPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject deathScreen = player.GetComponent<Player>().GetDeathScreen();

            deathScreen.SetActive(false);

            player.GetComponent<Player>().SetDead(false);

            player.transform.position = respawnPoint.transform.position;

            player.SetActive(true);

            // Acessar o respawnSprite a partir do jogador
            GameObject respawnSprite = player.GetComponent<Player>().GetRespawnSprite();

            // Destruir o respawnSprite se ele existir
            if (respawnSprite != null)
            {
                Destroy(respawnSprite);
            }
        }
    }
}
