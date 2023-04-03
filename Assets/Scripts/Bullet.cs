using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float damage;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float lifetime;

    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > lifetime)
        {
            GameObject.Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamagable damagable = collision.collider.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.onDamage(damage);
        }
        GameObject.Destroy(gameObject);
    }
}
