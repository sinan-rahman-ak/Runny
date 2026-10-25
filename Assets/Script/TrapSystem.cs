using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TrapSystem : MonoBehaviour
{
    public GameObject GameOverPanel;
    public AudioSource GameOverSound;
    public GameObject  WinnigPanel;
    public AudioSource WinnigSound;
    public GameObject Player;
    public AudioSource BackgroundSound;
    private bool HasPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        if (Player == null) Debug.LogError("Player is not assigned!");
        if (GameOverPanel == null) Debug.LogError("GameOverPanel is not assigned!");
        if (GameOverSound == null) Debug.LogError("GameOverSound is not assigned!");
        if (WinnigPanel == null) Debug.LogError("WinnigPanel is not assigned!");

        GameOverPanel.SetActive(false);
        WinnigPanel.SetActive(false);
        WinnigSound.Stop();
        HasPlayed = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Trap")
        {
            Debug.Log(collision.gameObject.tag);
            Player.SetActive(false);
            GameOverPanel.SetActive(true);
            GameOverSound.Play();
            BackgroundSound.Stop();

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FallTrap")
        {
            Debug.Log(collision.gameObject.tag);
            Player.SetActive(false);
            GameOverPanel.SetActive(true);
            GameOverSound.Play();
            BackgroundSound.Stop();
        }
        if (collision.gameObject.tag == "Finish" && !HasPlayed)
        {
            HasPlayed = true;
            Debug.Log(collision.gameObject.tag);
            WinnigPanel.SetActive(true);
            WinnigSound.Play();
            BackgroundSound.Stop();
        }
    }
}


