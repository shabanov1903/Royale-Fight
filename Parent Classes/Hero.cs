using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Hero : MonoBehaviour, IHero
{
    // � ������� ������� ���� ����� ��������
    // ��������� ��� ���� ��������
    public float health { get; set; }

    // ������� ������� �������� ��������� ��� ���� ��������
    public void Health(IBullet bullet)
    {
        health = health - bullet.damage;
    }

    // ������� ������������ ������� �����������
    // ���������� �������������� � ���������� ����������
    public virtual void Position() { }

    // ������� ��������� � ���������� ���������������� ������ �������
    // ������ ������� ��������� ��� ���� ���������� ����
    // ���� ��� ������� ����� - ��������� �� ������ �������
    public void Rotate(string Tag)
    {
        float enemyDistantions;
        Vector3 vectorToEnemy;
        GameObject Enemy;
        GameObject[] EnemyElements;
        EnemyElements = GameObject.FindGameObjectsWithTag(Tag);

        try
        {
            EnemyElements = FindObjects(Tag);
        }
        catch (PlayersException e)
        {
            if (e.Value == 0)
            {
                SceneManager.LoadScene("LoseScreen");
            }
            if (e.Value == 1)
            {
                SceneManager.LoadScene("WinScreen");
            }
            return;
        }

        float min = 0;
        int i = 0;
        int indexer = 0;

        foreach (GameObject enemy in EnemyElements)
        {
            enemyDistantions = (enemy.transform.position - transform.position).magnitude;
            if (enemyDistantions <= min || min == 0)
            {
                min = enemyDistantions;
                indexer = i;
            }
            i++;
        }

        Enemy = EnemyElements[indexer];
        vectorToEnemy = Enemy.transform.position - transform.position;
        vectorToEnemy.y = 0;
        if (vectorToEnemy != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(vectorToEnemy, Vector3.up);
        }
    }

    // ������� ������������ ����� ��������� � ����� � ������ ����������, ���� �� ���
    private GameObject[] FindObjects(string Tag)
    {
        GameObject[] EnemyElements = GameObject.FindGameObjectsWithTag(Tag);
        if (EnemyElements.Length == 0)
        {
            switch (Tag)
            {
                case "Player": throw new PlayersException("Players Die", 0);
                case "Enemy": throw new PlayersException("Enemyes Die", 1);
            }
        }
        return EnemyElements;
    }

    // ������ ������
    // ��������� ��� ���� ��������
    // ����������� �������� ��� force = 40
    // �� ������ ��������� isTrigger � ��������
    public void Throw(GameObject bulletObject, float force)
    {
        GameObject newBullet = Instantiate(
            bulletObject,
            new Vector3(transform.position.x + Mathf.Sign(transform.forward.x) * 1.0f,
                        transform.position.y + Mathf.Sign(transform.forward.y) * 3.0f,
                        transform.position.z + Mathf.Sign(transform.forward.z) * 1.0f),
            Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity = transform.forward * force + new Vector3(0, 1.5f, 0);
    }

    // ������ ���������
    // ��������� �� ���� ��������
    public void Death()
    {
        Destroy(gameObject);
    }
}