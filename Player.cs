using UnityEngine;

public class Player : Hero
{
    private string Opponent = "EnemyBullet";
    private Camera MainCamera;
    private Vector3 Offset;
    private bool Dragging;
    private float ZPosition;

    // Должно передаваться из синглтона
    private GameObject PlayerBullet;
    public float force = 40;

    void Start()
    {
        // Загрузка синглтона
        // var playerSingletone = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerSingletone>();
        var playerSingletone = PlayerSingletone.Instance;
        // Загрузка здоровья выбранного персонажа из базы данных
        DataBaseHero dbh = new DataBaseHero();
        var heroObject = dbh.GetObject(playerSingletone.player.hero);
        health = heroObject.health;

        // Загрузка префаба скина из базы данных
        DataBaseSkin dbs = new DataBaseSkin();
        var skinObject = dbs.GetObject(playerSingletone.player.skin);
        PlayerBullet = Resources.Load<GameObject>($@"Skins\{skinObject.name}");
        
        // Инициализация камеры
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate("Enemy");
        Position();
    }

    private void OnTriggerEnter(Collider bullet)
    {
        if (bullet.gameObject.tag == Opponent)
        {
            Health(bullet.gameObject.GetComponent<IBullet>());
            /*
                Несколько звуков можно сделать через GetComponents 
                AudioSource[] bsa = gameObject.GetComponents<AudioSource>();
                bsa[0].Play();
                bsa[1].Play();
            */
            gameObject.GetComponent<AudioSource>().Play(0);
        }

        if (health <= 0.0f)
        {
            Death();
        }

        Destroy(bullet.gameObject);
    }

    override public void Position()
    {
        if (Dragging)
        {
            ZPosition = MainCamera.WorldToScreenPoint(transform.position).z;

            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ZPosition);

            transform.position = MainCamera.ScreenToWorldPoint(position + new Vector3(Offset.x, Offset.y));

            transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);

            if (transform.position.z > 1) transform.position = new Vector3(transform.position.x, 0.0f, 1);
        }
    }

    private void OnMouseDown()
    {
        if (!Dragging)
        {
            BeginDrag();
        }
        AnimationStates(States.Walk);
    }
    private void OnMouseUp()
    {
        EndDrag();
        AnimationStates(States.Throw);
    }
    private void BeginDrag()
    {
        Dragging = true;
        Offset = MainCamera.WorldToScreenPoint(transform.position) - Input.mousePosition;
    }
    private void EndDrag()
    {
        Dragging = false;
    }

    private void AnimationStates(States state)
    {
        switch (state)
        {
            case States.Idle:
                {
                    gameObject.GetComponent<Animator>().SetBool("bWalk", false);
                    gameObject.GetComponent<Animator>().SetBool("bIdle", true);
                }; break;
            case States.Walk:
                {
                    gameObject.GetComponent<Animator>().SetBool("bIdle", false);
                    gameObject.GetComponent<Animator>().SetBool("bWalk", true);
                }; break;
            case States.Throw:
                {
                    gameObject.GetComponent<Animator>().SetBool("bThrow", true);
                }; break;
        }
    }
    public void Shot()
    {
        Throw(PlayerBullet, force);
        AnimationStates(States.Idle);
    }
}