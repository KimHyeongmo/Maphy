using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class terminal : MonoBehaviour
{
    public GameObject terminal_say;
    TextMeshProUGUI terminal_words;
    
    [TextArea]
    public string text;

    public Sprite terminal_on;
    public Sprite terminal_off;
    
    private void Awake()
    {
        terminal_words = terminal_say.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = terminal_on;
            terminal_say.SetActive(true);
            words_current = words();
            StartCoroutine(words_current);
        }
    }

    IEnumerator words_current;

    IEnumerator words()
    {
        yield return new WaitForSeconds(1f);

        foreach(char item in text)
        {
            terminal_words.text += item;
            yield return new WaitForSeconds(0.05f);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = terminal_off;
            terminal_words.text = "";
            StopCoroutine(words_current);
            terminal_say.SetActive(false);
        }
    }
    
}
