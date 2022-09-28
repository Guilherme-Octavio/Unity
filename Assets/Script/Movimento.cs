using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://youtu.be/XXfgdEE4S20?t=696
public class Movimento : MonoBehaviour
{
    private Rigidbody2D rb;

    public readonly float maxVelocity = 3;

    private readonly float rotationSpeed = 0.5F;

    #region Monobehavior API

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");

        ThrustForward(yAxis);
        Rotate(transform, (xAxis - (xAxis/0.8f)) * rotationSpeed);
    }

    #endregion

    #region Maneuvering API

    private void ClampVelocity()
    {
        float x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity);

        rb.velocity = new Vector2(x,y);
    }

    private void ThrustForward(float amount)
    {
        Vector2 force = transform.up * amount;

        rb.AddForce(force);
    }

    private void Rotate(Transform t, float amount)
    {
        t.Rotate(0, 0, amount);
    }
    #endregion

    // void Update()
    // {
    //     andar();
    // }

    // void andar()
    // {
    //     Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
    //     transform.position += movement * Time.deltaTime * Speed;
    // }
}
