using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    private SoundFXController soundFX;

    void Start()
    {
        soundFX = FindObjectOfType<SoundFXController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            soundFX.PlayEnemyDeath();

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}