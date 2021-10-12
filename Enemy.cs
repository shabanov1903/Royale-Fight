using System;
using UnityEngine;

public class Enemy : Hero
{
    private string Opponent = "PlayerBullet";

    // Генерация броска / пауза между бросками для конкретного врага
    public float delTime = 2;

    // Значение здоровья для конкретного врага
    public float HealtValue = 50;

    // Указать в инспекторе для конкретного врага из папки Enemyes Skins
    public GameObject EnemyBullet;

    // Скорость перемещения (оптимально 2)
    public float speed = 2;

    // Указать в инспекторе для конкретного врага (оптимально 40)
    public float force = 40;

    // Координаты прямоугольника для задания области движения персонажа
    [Header("Границы движения")]
    public int xMin = -10;
    public int xMax = 10;
    public int zMin = 5;
    public int zMax = 30;

    // Координаты следующей точки для перемещения в неё
    private Vector3 nextPoint;

    // генератор случайных чисел для генерирования координат точек
    private System.Random rnd;

    // Фиксация последнего времени броска для задействования таймера
    private DateTime lastTime;

    void Start()
    {
        // Фиксация текущего времени для начала броска
        lastTime = System.DateTime.Now;
        // Инициализация здоровья
        health = HealtValue;
        // Инициализация первой точки для перемещения
        rnd = new System.Random();
        nextPoint = new Vector3(Convert.ToSingle(rnd.Next(xMin, xMax)), 0, Convert.ToSingle(rnd.Next(zMin, zMax)));
    }

    // Update is called once per frame
    void Update()
    {
        Rotate("Player");
        Position();
        ThrowTimeController();
    }

    private void OnTriggerEnter(Collider bullet)
    {
        if (bullet.gameObject.tag == Opponent)
        {
            Health(bullet.gameObject.GetComponent<IBullet>());
            gameObject.GetComponent<AudioSource>().Play(0);
        }

        if (health <= 0.0f)
        {
            Death();
        }

        Destroy(bullet.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            nextPoint = new Vector3(Convert.ToSingle(rnd.Next(xMin, xMax)), 0, Convert.ToSingle(rnd.Next(zMin, zMax)));
        }
    }

    public override void Position()
    {
        if (transform.position == nextPoint)
        {
            nextPoint = new Vector3(Convert.ToSingle(rnd.Next(xMin, xMax)), 0, Convert.ToSingle(rnd.Next(zMin, zMax)));
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPoint, Time.deltaTime * speed);
    }

    // Функция вызывается в качестве события в анимации
    public void Shot()
    {
        Throw(EnemyBullet, force);
    }

    // Запуск снежка через интервал delTime (указанный в инспекторе)
    public void ThrowTimeController()
    {
        if (Convert.ToSingle((System.DateTime.Now - lastTime).TotalSeconds) > delTime)
        {
            lastTime = System.DateTime.Now;
            gameObject.GetComponent<Animator>().SetBool("bThrow", true);
        }
    }
}