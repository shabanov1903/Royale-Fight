using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IBullet
{
    public float damage { get; set; }

    private void Start()
    {
        // —читывание значени€ damage из базы данных
        // var playerSingletone = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerSingletone>();
        var playerSingletone = PlayerSingletone.Instance;
        var dbh = new DataBaseSkin();
        damage = dbh.GetObject(playerSingletone.player.skin).damage;
    }

    private void Update()
    {
        if (gameObject.transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }
}