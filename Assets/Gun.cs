using UnityEngine;

public class Gun : MonoBehaviour
{
    public string tagEnemy;
    public float maxDistance;
    public int damage;

    void Update()
    {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance))
        {
            if(hit.collider.tag == tagEnemy)
            {
                hit.collider.GetComponent<Enemy>().getDamage(damage);
            }
        }

    }
}
