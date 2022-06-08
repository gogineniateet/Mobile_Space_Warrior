using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    #region PUBLIC VARIABLES
    public static int lives = 3;
    public bool isGameOver  = false;
    public Transform bulletPosition;
    public const string TURN_ON_COROUTINE = "NextBullet";
    public AudioSource laserSound;
    #endregion

    #region PRIVATE VARIABLE
    private Rigidbody2D rb;
    private UIManager uiManager;
    private float timer;
    #endregion

    #region SINGLETON
    public static PlayerController instance;
    public static PlayerController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<PlayerController>();

                if (instance == null)
                {
                    GameObject container = new GameObject("Player");
                    instance = container.AddComponent<PlayerController>();
                }
            }
            return instance;
        }
    }
    #endregion



    #region MONIBEHAVIOUR METHOD
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
    private void OnEnable()
    {
        InputHandler.OnPanHeld += PositionOfShip;
        InputHandler.OnTouchAction += ShootBullets;
    }
    private void OnDisable()
    {
        InputHandler.OnPanHeld -= PositionOfShip;
        InputHandler.OnTouchAction -= ShootBullets;
    }
    #endregion

    #region PUBLIC METHODS
    private void Update()
    {
        timer = timer+Time.deltaTime;
    }
    public void PositionOfShip(Touch touch)
    {
        Vector3 shipPosition = Camera.main.ScreenToWorldPoint(touch.position); //Changing the pixelcoordinate to world coordinates
        shipPosition.z = transform.position.z;
        shipPosition.y = transform.position.y;

        float distance = Vector3.Distance(transform.position, shipPosition); //Calculating distance between player current position and touch position
        for (float i = 0; i < distance; i += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(transform.position, shipPosition, i); // Transforming from current position slowly to the touch position 
        }
        transform.position = shipPosition;
    }
    public void LostLife(int life)
    {
        lives = lives - life;
        Debug.Log("life" + lives);
        StartCoroutine(StartInvincibilityTimer(2.5f));
        uiManager.UpdateLives(lives);

        if (lives <= 0 || timer == 10)
        {
            Debug.Log("game over");
            SceneManager.LoadScene(3);

        }
    }    

    public IEnumerator StartInvincibilityTimer(float timeLimit)
    {
        GetComponent<Collider2D>().enabled = false;
        SpriteRenderer[] spriteRenderer = GetComponentsInChildren<SpriteRenderer>();
        //Debug.Log(spriteRenderer);        
        float timer = 0;
        float blinkSpeed = 0.25f;
        while (timer < timeLimit)
        {
            yield return new WaitForSeconds(blinkSpeed);
            spriteRenderer[0].enabled = !spriteRenderer[0].enabled;
            spriteRenderer[1].enabled = !spriteRenderer[1].enabled;
            timer += blinkSpeed;
        }
        spriteRenderer[0].enabled = true;
        spriteRenderer[1].enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }

    public void ShootBullets(Touch t)
    {
        ShootTheBullets();
        Debug.Log("Shoot the Bullets");

    }
    private void ShootTheBullets()
    {
        //NextBullet();
        laserSound.Play();
        GameObject pooledBullet = PoolManager.Instance.Spawn(Constants.PLAYER_BULLET_PREFAB);
        pooledBullet.transform.position = bulletPosition.position;
        //Instantiate(bulletPrefab, bulletPosition.position, Quaternion.identity);
    }
    IEnumerator NextBullet()
    {

        yield return new WaitForSeconds(5f);
        Debug.Log("Coroutine Function");
    }



    #endregion






}
