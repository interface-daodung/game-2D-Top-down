using UnityEngine;
using UnityEngine.UI;
using Unity.Cinemachine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    [SerializeField] protected float maxHp = 500f;
    [SerializeField] private Image HpBar;
    [SerializeField] private GameObject gamemanager;
    [SerializeField] public CinemachineCamera cam;
    public float zoomSpeed = 1f;
    public int minFOV = 3;
    public int maxFOV = 12;
    private AudioManager audioManager;
    private GameUI gameUI;
    protected float currentHp;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        currentHp = maxHp;
        audioManager = FindAnyObjectByType<AudioManager>();
        gameUI = FindAnyObjectByType<GameUI>();
        updateHpBar();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Zoom();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameUI.StarPause();
        }
    }

    private void Zoom()
    {
        if (cam == null) return;

        // Lấy giá trị scroll (nút lăn chuột)
        float scroll = Input.GetAxis("Mouse ScrollWheel");


        if (Mathf.Abs(scroll) > 0.01f)
        {
            // print("aaaaaaaaaaaaaaaaaaaaaaaaa");
            // Lấy LensSettings hiện tại
            var lens = cam.Lens;
            // Giảm OrthographicSize khi scroll lên (zoom in), tăng khi scroll xuống (zoom out)
            lens.OrthographicSize -= Mathf.RoundToInt(scroll * zoomSpeed);
            // Giới hạn OrthographicSize trong khoảng
            lens.OrthographicSize = Mathf.Clamp(lens.OrthographicSize, minFOV, maxFOV);
            // Gán lại LensSettings đã chỉnh sửa
            cam.Lens = lens;
        }
    }

    void Move()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        rb.linearVelocity = movement * speed;

        spriteRenderer.flipX = movement.x < 0;
        if (movement != Vector2.zero)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
    public void heal(float amount)
    {
        currentHp += amount;
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);
        updateHpBar();
    }
    public void takeDamage(float damage)
    {
        currentHp -= damage;
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);
        updateHpBar();
        if (currentHp <= 0)
        {
            die();
        }
    }
    void die()
    {
        gameUI.StarGameOver();
        Destroy(gameObject);
    }
    private void updateHpBar()
    {
        if (HpBar != null)
        {
            HpBar.fillAmount = currentHp / maxHp;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            EnemyBullet enemyBullet = collision.GetComponent<EnemyBullet>();
            takeDamage(enemyBullet.Damage);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Usb"))
        {
            print("Get Usb");
            gameUI.StarWinMenu();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Enegry"))
        {
            print("Get Enegry");
            audioManager.PlayEnergySound();
            gamemanager.GetComponent<Gamemanager>().addEnegry();
            Destroy(collision.gameObject);
        }
    }
}
