using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiuBangCH : MonoBehaviour
{
    public float speed = 3.0f;

    public int maxHealth = 5;
    //public int inicialScore;
    public float timeInvincible = 2.0f;
    //public float timeSlowed = 2.0f;
    //public GameObject projectilePrefab;
    //public GameObject screwPrefab;
    //bool isSlowed;
    //float speedTimer;

    public int health { get { return currentHealth; } }
    int currentHealth;
    //public int score { get { return currentScore; } }
    //int currentScore;
    bool isInvincible;
    float invincibleTimer;

    //bool enableShooting;
    //int shoots;

    Rigidbody2D rigidbody2d;



    //Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();

        currentHealth = maxHealth;
        //currentScore = 0;

        //enableShooting = false;
        //shoots = 5;


    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        //animator.SetFloat("Look X", lookDirection.x);
        //animator.SetFloat("Look Y", lookDirection.y);
        //animator.SetFloat("Speed", move.magnitude);

        Vector2 position = rigidbody2d.position;

        position = position + move * speed * Time.deltaTime;

        rigidbody2d.MovePosition(position);

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        //if (isSlowed)
        //{
           // speedTimer -= Time.deltaTime;
            //if (speedTimer < 0)
            //{
                //isSlowed = false;
                //ChangeSpeed();
                //Debug.Log("Speed: " + speed);
            //}
        //}


        //if (Input.GetKeyDown(KeyCode.C))
       // {
            //if (enableShooting && shoots > 0)
            //{
                //Launch();
                //shoots--;
            //}
       // }


        //if (Input.GetKeyDown(KeyCode.V))
       // {
         //   LaunchScrew();
        //}



    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        Debug.Log(currentHealth + "/" + maxHealth);
    }

    //public void ChangeScore(int amount)
    //{
      //  currentScore = currentScore + amount;
       // Debug.Log(currentScore);
    //}

    //public void ChangeSpeed()
    //{
      //  speed = speed * 2;
       // Debug.Log("Speed: " + speed);
    //}

    //public void ChangeSpeedLow()
    //{

        //speed = speed / 2;
       // Debug.Log("Speed: " + speed);

       // isSlowed = true;
        //speedTimer = timeSlowed;

    //}

    //void Launch()
    //{
      //  GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        //Projectile projectile = projectileObject.GetComponent<Projectile>();
        //projectile.Launch(lookDirection, 300);

        //animator.SetTrigger("Launch");
    //}

    //void LaunchScrew()
    //{
       // GameObject screwObject = Instantiate(screwPrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        //ScrewProjectile screwProjectile = screwObject.GetComponent<ScrewProjectile>();
       // screwProjectile.LaunchScrew(lookDirection, 300);

       // animator.SetTrigger("Launch");
   // }

    //public void Shooting()
    //{
     //   enableShooting = true;
        //shoots = 5;
       // Debug.Log("Shoots: ");
   // }
}
