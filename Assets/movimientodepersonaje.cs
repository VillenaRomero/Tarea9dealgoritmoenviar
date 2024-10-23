using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientodepersonaje : MonoBehaviour
{
    public float speedx;
    public float speedy;
    private Rigidbody2D _compRigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        _compRigidbody2D.velocity = new Vector2(speedx * horizontal, speedy * vertical);
    }
}
