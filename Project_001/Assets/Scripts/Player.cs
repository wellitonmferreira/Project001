using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public Animator anim;
    public float speed = 10;

    [SerializeField] GameObject player;
    [SerializeField] GameObject playerRespawnPoint;
    [SerializeField] GameObject respawnSpritePrefab;
    [SerializeField] GameObject deathScreen;
    [SerializeField] TextMeshProUGUI deathCountText;

    private Vector3 initialPosition;
    private bool isDead = false;
    private GameObject respawnSprite;
    private int deathCount = 0;

    void Start()
    {
        initialPosition = transform.position;
        deathCountText.text = "Deaths: 0";
    }

    void Update()
    {
        if (!isDead)
        {
            Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f).normalized;

            anim.SetFloat("Horizontal", movement.x);
            anim.SetFloat("Vertical", movement.y);
            anim.SetFloat("Speed", movement.magnitude);

            transform.position = transform.position + movement * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap") && !isDead)
        {
            // Incrementar o contador de mortes
            deathCount++;

            // Atualizar algum elemento na tela com o valor do contador de mortes
            UpdateDeathCountUI();

            // Configurar o estado de morte
            isDead = true;

            // Instanciar o sprite de respawn no local da colisão
            respawnSprite = Instantiate(respawnSpritePrefab, player.transform.position, Quaternion.identity);

            // Desativar o objeto do jogador
            gameObject.SetActive(false);

            // Ativar a tela de morte
            deathScreen.SetActive(true);
        }
    }

    private void UpdateDeathCountUI()
    {
        deathCountText.text = "Deaths: " + deathCount.ToString();
    }

    // Método para configurar o estado de morte
    public void SetDead(bool value)
    {
        isDead = value;
    }

    // Método para acessar o objeto de tela de morte
    public GameObject GetDeathScreen()
    {
        return deathScreen;
    }

    // Método para acessar o respawnSprite
    public GameObject GetRespawnSprite()
    {
        return respawnSprite;
    }
}
