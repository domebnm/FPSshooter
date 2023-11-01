using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] float healthMax;
    float health;

    [SerializeField] Image healthBar;

    [SerializeField] float speed;
    [SerializeField] float forceUp;
    [SerializeField] Transform camTr;

    Rigidbody rb;

    [SerializeField] KeyCode up;
    [SerializeField] KeyCode down;
    [SerializeField] KeyCode left;
    [SerializeField] KeyCode right;
    [SerializeField] KeyCode jump;


    private bool floor;
    private Vector3 moveVec
    {
        get
        {
            Vector3 dir = Vector3.zero;
            if (Input.GetKey(up)) { dir = transform.forward; }
            if (Input.GetKey(down)) { dir = -transform.forward; }
            if (Input.GetKey(right)) { dir = transform.right; }
            if (Input.GetKey(left)) { dir = -transform.right; }

            return dir;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = healthMax;
    }
    private void FixedUpdate()
    {
        Move();
        Jump();
    }
    private void Move()
    {
        rb.AddForce(moveVec * speed, ForceMode.Impulse);
    }
    private void Jump()
    {
        if (Input.GetKey(jump))
        {
            Debug.Log(floor);
            if (floor)
            {
                rb.AddForce(Vector3.up * forceUp, ForceMode.Impulse);
            }
        }
    }

    public void getDamage(int damage)
    {
        health -= damage;
        healthBar.fillAmount = health / healthMax;
        if(health < 0)
        {
            Debug.Log("end game");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Ground")floor = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground") floor = false;
    }
}
