using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicaAnimacion : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;

    private Animator anim;

    [SerializeField] float fuerzaSalto = 4.5f;
    [SerializeField] Rigidbody rbJugador;

    bool estaEnElSuelo;   
    float x, y;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoYSalto();
    }

    void MovimientoYSalto()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        
        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);

        anim.SetFloat("velX", x);
        anim.SetFloat("velY", y);

        if(Input.GetKeyDown(KeyCode.Space) && estaEnElSuelo)
        {
            rbJugador.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            estaEnElSuelo = true;
        }
    }
}
