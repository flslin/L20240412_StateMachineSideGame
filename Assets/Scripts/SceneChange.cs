using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public Collider2D door;
    public Image image;
    [SerializeField] Enemy_Skeleton enemy;
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.CompareTag("Player"))
    //    {
    //        Debug.Log("col충돌");
    //        Change();
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("trig충돌");
            enemy.SetIdleState();
            Debug.Log(enemy.stateMachine.currentState);
            Change();
        }
    }

    void Change()
    {
        StartCoroutine(SChange());
    }

    IEnumerator SChange()
    {
        float startAlpha = 0;
        while (startAlpha < 1.0f)
        {
            startAlpha += 0.01f;
            yield return new WaitForSeconds(0.015f);
            image.fillAmount = startAlpha;
            //image.color = new Color(0, 0, 0, startAlpha);
        }
        SceneManager.LoadScene("New Scene");
    }
}
