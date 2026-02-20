using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
public class PlayerControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody rb;
    private float movimientoX;
    private float movimientoY;
    private float velocidad = 10.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movimiento = movementValue.Get<Vector2>();
        movimientoX = movimiento.x;
        movimientoY = movimiento.y;
    }

    void FixedUpdate()
    {
        Vector3 movimiento = new Vector3(velocidad*movimientoX, 0.0f, velocidad*movimientoY);
        rb.AddForce(movimiento);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("He muerto");
            Destroy(gameObject);
        }
    }
}
