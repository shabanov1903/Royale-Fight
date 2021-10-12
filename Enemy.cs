using System;
using UnityEngine;

public class Enemy : Hero
{
    private string Opponent = "PlayerBullet";

    // ��������� ������ / ����� ����� �������� ��� ����������� �����
    public float delTime = 2;

    // �������� �������� ��� ����������� �����
    public float HealtValue = 50;

    // ������� � ���������� ��� ����������� ����� �� ����� Enemyes Skins
    public GameObject EnemyBullet;

    // �������� ����������� (���������� 2)
    public float speed = 2;

    // ������� � ���������� ��� ����������� ����� (���������� 40)
    public float force = 40;

    // ���������� �������������� ��� ������� ������� �������� ���������
    [Header("������� ��������")]
    public int xMin = -10;
    public int xMax = 10;
    public int zMin = 5;
    public int zMax = 30;

    // ���������� ��������� ����� ��� ����������� � ��
    private Vector3 nextPoint;

    // ��������� ��������� ����� ��� ������������� ��������� �����
    private System.Random rnd;

    // �������� ���������� ������� ������ ��� �������������� �������
    private DateTime lastTime;

    void Start()
    {
        // �������� �������� ������� ��� ������ ������
        lastTime = System.DateTime.Now;
        // ������������� ��������
        health = HealtValue;
        // ������������� ������ ����� ��� �����������
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

    // ������� ���������� � �������� ������� � ��������
    public void Shot()
    {
        Throw(EnemyBullet, force);
    }

    // ������ ������ ����� �������� delTime (��������� � ����������)
    public void ThrowTimeController()
    {
        if (Convert.ToSingle((System.DateTime.Now - lastTime).TotalSeconds) > delTime)
        {
            lastTime = System.DateTime.Now;
            gameObject.GetComponent<Animator>().SetBool("bThrow", true);
        }
    }
}