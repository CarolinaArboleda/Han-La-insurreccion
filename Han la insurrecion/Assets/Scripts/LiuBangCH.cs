using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiuBangCH : MonoBehaviour
{
    public float speed = 3.0f;
    public float speedGuard = 0f;

    public int initMaxHealth = 5;
    public int additMaxHealth = 0;
    public int maxHealth = 5;

    //public int inicialScore;
    public float timeInvincible = 2.0f;
   
    public GameObject projectilePrefab;
    //public GameObject screwPrefab;
    

    public Transform attackPoint;
    public Transform attackPoint2;
    public float attackRange = 0.5f;
    public int attackDamage = 40;
    public int attackBonus = 0;
    public float attackRate = 2f; //cooldown del ataque a melee
    float nextAttackTime = 0f;
    public LayerMask enemyLayers;
    private Animator anim;
    public GameObject IcePrefab;

    public GameObject targetDragon;
    public GameObject targetFenix;
    public GameObject myself;

    public bool conseguidoCongelar = false;
    public bool conseguidoFuego = false;
    public bool conseguidoDash = false;

    public bool dragon_superado;
    public bool fenix_superado;
    public GameObject pickupDragon;

    bool isDashing = false;
    float dashTimer;
    public float timeDashing = 1.0f;

    public int health { get { return currentHealth; } }
    public int currentHealth;
    //public int score { get { return currentScore; } }
    //int currentScore;
    bool isInvincible;
    float invincibleTimer;

    bool cooldownIce;
    float cooldownIceTimer;
    public float timecooldownIce = 2.0f;

    bool once = true;
    bool once_fenix = true;

    bool cooldownDash;
    float cooldownDashTimer;
    public float timecooldownDash = 2.5f;

    bool cooldownFire;
    float cooldownFireTimer;
    public float timecooldownFire = 2.0f;


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
        anim = GetComponent<Animator>();
        anim.SetInteger("Estado", 0);
        speedGuard = speed;
    }

    // Update is called once per frame
    void Update()
    {
        maxHealth = initMaxHealth + additMaxHealth;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
            anim.SetInteger("Estado", 0);
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

        if (conseguidoDash)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Dash();

                dashTimer -= Time.deltaTime;
            }
        }

        if (cooldownIce)
        {
            cooldownIceTimer -= Time.deltaTime;

            if (cooldownIceTimer < 0)
                cooldownIce = false;
        }

        if (cooldownFire)
        {
            cooldownFireTimer -= Time.deltaTime;
            if (cooldownFireTimer < 0)
                cooldownFire = false;
        }

        if (cooldownDash)
        {
            cooldownDashTimer -= Time.deltaTime;
            if (cooldownDashTimer < 0)
                cooldownDash = false;
        }

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
                ataque_melee();
            }


        }

        if (conseguidoCongelar)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                LaunchIce();
            }
        }



        //animator.SetTrigger("Launch");





        if (isDashing)
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer < 0)
            {
                isDashing = false;
                speed = speedGuard;
                Debug.Log("Speed: " + speed);
            }
        }

        if (conseguidoFuego)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //if (enableShooting && shoots > 0)
                //{
                Launch();
                //shoots--;
            }
        }

        if (dragon_superado && once)
        {
            myself.transform.position = targetDragon.transform.position;
            once = false;

        }

        if (fenix_superado && once_fenix)
        {
            myself.transform.position = targetFenix.transform.position;
            once_fenix = false;
        }

        //if (Input.GetKeyDown(KeyCode.V))
        // {
        //   LaunchScrew();
        //}

        if (currentHealth <= 0)
        {
            FindObjectOfType<manager>().GameOver();
            
        }

        }

        void Attack()
        {

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            Collider2D[] hitEnemies2 = Physics2D.OverlapCircleAll(attackPoint2.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.GetComponent<EnemigoComun>())
                {
                enemy.GetComponent<EnemigoComun>().takeDamage(attackDamage + attackBonus);
                }

                if (enemy.GetComponent<fenix>())
                {
                    enemy.GetComponent<fenix>().takeDamage(attackDamage + attackBonus);
                }
            }       

            foreach (Collider2D enemy in hitEnemies2)
            {
                if (enemy.GetComponent<EnemigoComun>())
                {
                    enemy.GetComponent<EnemigoComun>().takeDamage(attackDamage + attackBonus);
                }

                if (enemy.GetComponent<fenix>())
                {
                    enemy.GetComponent<fenix>().takeDamage(attackDamage + attackBonus);
                }
            }

        }


        void OnDrawGizmosSelected()
        {
            if (attackPoint == null)
                return;
            if (attackPoint2 == null)
                return;

            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
            Gizmos.DrawWireSphere(attackPoint2.position, attackRange);
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

    void LaunchIce()
    {
        if (cooldownIce)
            return;

        GameObject iceObject = Instantiate(IcePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Congelar congelar = iceObject.GetComponent<Congelar>();
        congelar.LaunchIce(lookDirection, 800);
        cooldownIce = true;
        cooldownIceTimer = timecooldownIce;
    }

    void ataque_melee()
    {
        anim.SetInteger("Estado", 3);
        StartCoroutine("returne");
    }

    IEnumerator returne()
    {
        yield return new WaitForSeconds(.06f);
        anim.SetInteger("Estado", 0);
    }

    //public void ChangeScore(int amount)
    //{
    //  currentScore = currentScore + amount;
    // Debug.Log(currentScore);
    //}

    

    public void Dash()
    {
        if (cooldownDash)
            return;

        speed = speed * 3.4f;
        Debug.Log("Speed: " + speed);

        isDashing = true;
        dashTimer = timeDashing;

        cooldownDash = true;
        cooldownDashTimer = timecooldownDash;

    }
    void Launch()
        {
        if (cooldownFire)
            return;

        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        BolaFuego projectile = projectileObject.GetComponent<BolaFuego>();
        projectile.Launch(lookDirection, 800);
        cooldownFire = true;
        cooldownFireTimer = timecooldownFire;

        //animator.SetTrigger("Launch");
    }

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