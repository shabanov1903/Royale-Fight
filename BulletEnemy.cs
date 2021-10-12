using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour, IBullet
{
    public float damage { get; set; }

    public float DamageValue;

    private void Start()
    {
        damage = DamageValue;
    }

    private void Update()
    {
        if (gameObject.transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }
}