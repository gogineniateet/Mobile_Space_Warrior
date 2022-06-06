using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region PUBLIC VARIABLES
    Rigidbody2D rb;
    public int lives = 3;
    #endregion

    #region PRIVATE VARIABLE
    private UIManager uiManager;
    #endregion

    #region MONOBEHAVIOUR METHODS
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
    }
    private void OnEnable()
    {
        InputHandler.OnPanHeld += PositionOfShip;
    }
    private void OnDisable()
    {
        InputHandler.OnPanHeld -= PositionOfShip;
    }
    #endregion

    #region PUBLIC METHODS
    public void PositionOfShip(Touch touch)
    {
        //Debug.Log("Method");
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
        uiManager.UpdateLives(lives);
        //Debug.Log("life" + lives);
        StartCoroutine(StartInvincibilityTimer(2.5f));
    }
    #endregion

    public IEnumerator StartInvincibilityTimer(float timeLimit)
    {
        GetComponent<Collider2D>().enabled = false;

        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        float timer = 0;
        float blinkSpeed = 0.25f;

        while (timer < timeLimit)
        {
            yield return new WaitForSeconds(blinkSpeed);

            spriteRenderer.enabled = !spriteRenderer.enabled;
            timer += blinkSpeed;
        }
        spriteRenderer.enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }
}
