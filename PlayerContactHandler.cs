using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerContactHandler : MonoBehaviour
{
    public string nextLevelName = "Level 1";
    public Image itemImage;
    public PlayerAudioController audioController;
    bool canWinLevel = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player Tocou no inimigo e perdeu");
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Debug.Log("Pegou o Item");
            Destroy(collision.gameObject);
            itemImage.color = Color.white;
            canWinLevel = true;
            audioController.PlayGetItem();
        }

        if (collision.gameObject.CompareTag("FinalPoint"))
        {
            if (canWinLevel)
            {
                Debug.Log("Ganhou o jogo");
                SceneManager.LoadScene(nextLevelName);

            } else
            {
                Debug.Log("NÃO ganhou o jogo");
            }
        }
    }
}