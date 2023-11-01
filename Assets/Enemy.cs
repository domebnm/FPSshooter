using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] float healthMax;
    float health;
    [SerializeField] UnityEngine.UI.Image healthBar;

    [SerializeField] int damage;

    [SerializeField] Transform[] pointTr;
    private int i;

    [SerializeField] float time;
    [SerializeField] float speed;
    [SerializeField] float speedRot;
    IEnumerator enumerator;

    Rigidbody rb;
    void Start()
    {
        health = healthMax;
        rb = GetComponent<Rigidbody>();
        enumerator = ff();
        StartCoroutine(enumerator);
    }
    public void getDamage(int damage)
    {
        health -= damage;
        healthBar.fillAmount = health / healthMax;
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }

    private Vector3 vecDir
    {
        get 
        {
            return new Vector3(pointTr[i].position.x - transform.position.x, 0f,
                        pointTr[i].position.z - transform.position.z);
        }
    }
    IEnumerator ff()
    {
        while (true)
        {
            while (vecDir.magnitude > .2f)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(vecDir), speedRot * Time.fixedDeltaTime);
                rb.velocity += vecDir.normalized * speed;
                yield return new WaitForFixedUpdate();
            }
            rb.velocity = Vector3.zero;
            yield return new WaitForSeconds(time);
            i++;
            if(i == pointTr.Length) { i = 0; }
        }
    }
}
