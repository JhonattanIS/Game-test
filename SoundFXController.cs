using UnityEngine;

public class SoundFXController : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip enemyDeathSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayEnemyDeath()
    {
        audioSource.PlayOneShot(enemyDeathSound);
    }
}