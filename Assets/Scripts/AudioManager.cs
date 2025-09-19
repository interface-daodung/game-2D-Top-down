using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource BMG;
    [SerializeField] private AudioSource SE;

    [SerializeField] private AudioClip BackgroundMusic;
    [SerializeField] private AudioClip BossMusic;
    [SerializeField] private AudioClip EnergySound;
    [SerializeField] private AudioClip GunShotSound;
    [SerializeField] private AudioClip GunReloadSound;

    void Start()
    {
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        BMG.Stop();
        BMG.clip = BackgroundMusic;
        BMG.Play();
    }

    public void PlayBossMusic()
    {
        BMG.Stop();
        BMG.clip = BossMusic;
        BMG.Play();
    }

    public void PlayEnergySound()
    {
        SE.PlayOneShot(EnergySound);
    }
    public void PlayGunShotSound()
    {
        SE.PlayOneShot(GunShotSound);
    }
    public void PlayGunReloadSound()
    {
        SE.PlayOneShot(GunReloadSound);
    }
}
