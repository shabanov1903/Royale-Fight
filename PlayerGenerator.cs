using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGenerator : MonoBehaviour
{
    public int NumberOfPersons;

    // Start is called before the first frame update
    public void Start()
    {
        // Загрузка синглтона
        // var playerSingletone = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerSingletone>();
        var playerSingletone = PlayerSingletone.Instance;

        // Загрузка выбранного персонажа из базы данных
        DataBaseHero dbh = new DataBaseHero();
        var heroObject = dbh.GetObject(playerSingletone.player.hero);
        var heroLoadObject = Resources.Load<GameObject>($@"Heroes\{heroObject.name}");
        heroLoadObject.GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(@"Animators\Player");
        heroLoadObject.AddComponent<Player>();

        switch (NumberOfPersons)
        {
            case 1:
                {
                    Instantiate(heroLoadObject, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
                }; break;
            case 2:
                {
                    Instantiate(heroLoadObject, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
                    Instantiate(heroLoadObject, new Vector3(10.0f, 0.0f, 0.0f), Quaternion.identity);
                }; break;
            case 3:
                {
                    Instantiate(heroLoadObject, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
                    Instantiate(heroLoadObject, new Vector3(10.0f, 0.0f, 0.0f), Quaternion.identity);
                    Instantiate(heroLoadObject, new Vector3(-10.0f, 0.0f, 0.0f), Quaternion.identity);
                }; break;
        }
    }
}
