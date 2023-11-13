using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour

{
    private float speed;
    public float Speed 
    {   
        get { return speed; }
        set { speed = value; } 
    }

    private float jumpForce;
    public float JumpForce 
    {
        get { return jumpForce; }
        set { jumpForce = value; }
    }

    private bool isAlive;
    public bool IsAlive
    {
        get { return isAlive; }
        set { isAlive = value; }
    }

    private Rigidbody2D rb;
    public Rigidbody2D Rb 
    {
        get { return rb; }
        set { rb = value; }
    }

    [SerializeField] private ParticleSystem gdParticulas;
    public ParticleSystem GDParticulas
    {
        get { return gdParticulas; }
        set { gdParticulas = value; }
    }

    [SerializeField] private TrailRenderer gdTrail;
    public TrailRenderer GDTrail
    {
        get { return gdTrail; }
        set { gdTrail = value; }
    }

    public Transform CubeVisual;
    public Sprite nave, ufo, cubo;
    public AudioClip explode;
    public ParticleSystem deathParticles;

    public enum Vehiculos { Cubo = 0, Nave = 1, Ufo = 2 }
    private Vehiculos currentvehiculo;
    public Vehiculos CurrentVehiculo
    {
        get { return currentvehiculo; }
        set {   currentvehiculo = value; }
    }
    private float lastOrbClickTime;
    private float lastUfoJumpTime;
    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        speed = 530f;
        JumpForce = 500f;
        IsAlive = true;
        lastUfoJumpTime = 0;
        lastOrbClickTime = 0;
    }
    private void Update()
    {
        if (rb.velocityY < -24.2f)
        {
            rb.velocity = new Vector2(rb.velocityX, -24.2f);
        }
        Invoke(CurrentVehiculo.ToString(), 0);
        Regresar();
    }
    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = Speed * Time.fixedDeltaTime;
        rb.velocity = velocity;
    }
    private void Cubo()
    {
        bool WasGround;

        rb.gravityScale = 12.41067f;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = cubo;

        Debug.DrawRay(transform.position, Vector3.down * 0.5f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.5f))
        {
            WasGround = true;
            GDTrail.emitting = false;
            GDParticulas.Play();
        }
        else
        {
            WasGround = false;
        }

        if (WasGround)
        {
            Vector3 Rotation = CubeVisual.rotation.eulerAngles;
            Rotation.z = Mathf.Round(Rotation.z / 90) * 90;
            CubeVisual.rotation = Quaternion.Euler(Rotation);
        }
        else
        {
            CubeVisual.Rotate(Vector3.back, 452.4152186f * Time.deltaTime);
        }
        if (WasGround)
        {
            Jump(WasGround);
        }

    }
    private void Nave()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = nave;
        GDTrail.emitting = true;

        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * 2);
        if (Input.GetMouseButton(0) || UnityEngine.Input.GetKey(KeyCode.Space))
        {
            GDParticulas.Play();
            rb.gravityScale = -4.314969f;
            Debug.Log("Click");
        }
        else
        {
            rb.gravityScale = 4.314969f;
        }
    }
    private void Ufo()
    {
        GDTrail.emitting = true;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = ufo;

        rb.gravityScale = 9.314969f;
        if ((Input.GetMouseButton(0) || UnityEngine.Input.GetKey(KeyCode.Space)) && Time.time > lastUfoJumpTime + 0.20)
        {
            GDParticulas.Play();
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
            lastUfoJumpTime = Time.time;
        }
    }
    private void Jump(bool WasGround )
    {
        if (WasGround)
        {
            Vector3 Rotation = CubeVisual.rotation.eulerAngles;
            Rotation.z = Mathf.Round(Rotation.z / 90) * 90;
            CubeVisual.rotation = Quaternion.Euler(Rotation);

            if (Input.GetMouseButton(0) || UnityEngine.Input.GetKey(KeyCode.Space))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * 26.6581f, ForceMode2D.Impulse);
            }
        }
        else
        {
            CubeVisual.Rotate(Vector3.back, 452.4152186f * Time.deltaTime);
        }
    }

    public void Hit()
    {
        IsAlive = false;

        if (IsAlive == false)
        {
            deathParticles.Play();
            Invoke("Restart", 1.5f);
            gameObject.SetActive(false);
            Camera.main.GetComponent<AudioSource>().PlayOneShot(explode);
        }
    }

    private void Regresar()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }
    public void Restart()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void pad(float fuerza_pad)
    {
        GDTrail.emitting = true;
        rb.AddForce(Vector2.up * fuerza_pad, ForceMode2D.Impulse);
    }
    public void Orbe(float fuerza_orbe)
    {
        if ((Input.GetMouseButton(0) || UnityEngine.Input.GetKey(KeyCode.Space)) && Time.time > lastOrbClickTime + 0.10f)
        {
            rb.AddForce(Vector2.up * fuerza_orbe, ForceMode2D.Impulse);
            lastOrbClickTime = Time.time;
            GDTrail.emitting = true;
        }
    }
    public void Portal(Vehiculos vehiculos)
    {
        CurrentVehiculo = vehiculos;
    }
}
