using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSlash : MonoBehaviour
{

    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //IDamagable damagable = collision.collider.GetComponent<IDamagable>();
        //if (damagable != null)
        //{
        //    damagable.onDamage(10);
        //}
        GameObject.Destroy(gameObject);
    }
}
