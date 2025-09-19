using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shotDelay = 1f;
    [SerializeField] private int MaxAmount = 20;
    [SerializeField] private int currentAmount;
    [SerializeField] private TextMeshProUGUI AmountText;
    private AudioManager audioManager;

    private float nextShotTime;
    void Start()
    {
        currentAmount = MaxAmount;
        UpdateAmountText();
        nextShotTime = 0f;
        audioManager = FindAnyObjectByType<AudioManager>();

    }

    // Update is called once per frame
    void Update()
    {
        rotateGun();
        Shoot();
        Reload();
    }

    void rotateGun()
    {
        Vector3 mousePos = Input.mousePosition;
        if (mousePos.x < 0 || mousePos.x > Screen.width || mousePos.y < 0 || mousePos.y > Screen.height)
        {
            return;
        }
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (angle > 90 || angle < -90)
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void Shoot()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextShotTime && currentAmount > 0)
        {
            nextShotTime = Time.time + shotDelay;
            audioManager.PlayGunShotSound();
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            currentAmount--;
            UpdateAmountText();
        }
    }
    void Reload()
    {
        if (Input.GetMouseButton(1) && currentAmount < MaxAmount)
        {
            audioManager.PlayGunReloadSound();
            currentAmount = MaxAmount;
            UpdateAmountText();
        }
    }

    private void UpdateAmountText()
    {
        if (currentAmount > 0)
        {
            AmountText.text = currentAmount.ToString();
        }
        else
        {
            AmountText.text = "Reload!";
        }

    }

}
