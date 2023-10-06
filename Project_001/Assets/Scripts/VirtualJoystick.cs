using UnityEngine;

public class VirtualJoystick : MonoBehaviour
{
    public Animator anim;
    public float speed = 10;

    [SerializeField] GameObject beginPoint;

    private Vector3 startPosition;
    private Vector3 moveDirection;

    void Start()
    {
        transform.position = beginPoint.transform.position;
    }

    void Update()
    {
        // Verifique se há toques na tela
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Considere apenas o primeiro toque

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Registre a posição inicial do toque
                    startPosition = touch.position;
                    break;
                case TouchPhase.Moved:
                    // Converta a posição do toque e a posição inicial para Vector3
                    Vector3 startPosition3D = new Vector3(startPosition.x, startPosition.y, 0f);
                    Vector3 touchPosition3D = new Vector3(touch.position.x, touch.position.y, 0f);

                    // Calcule o vetor de movimento com base na diferença entre as posições
                    moveDirection = (touchPosition3D - startPosition3D).normalized;

                    // Atualize a animação do jogador
                    anim.SetFloat("Horizontal", moveDirection.x);
                    anim.SetFloat("Vertical", moveDirection.y);
                    anim.SetFloat("Speed", moveDirection.magnitude);

                    // Movimento do jogador com base na direção do movimento
                    transform.position += moveDirection * speed * Time.deltaTime;
                    break;
                case TouchPhase.Ended:
                    // Quando o toque é liberado, pare o movimento do jogador
                    moveDirection = Vector3.zero;
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            anim.Play("Damage");
            transform.position = beginPoint.transform.position;
        }
    }
}
