using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private Collider2D door;
    [SerializeField] private Image image;
    [SerializeField] private Enemy_Skeleton enemy;
    [SerializeField] private Player player;

    [SerializeField] private TextMesh text;
    [SerializeField] private MeshRenderer rend;

    private void Awake()
    {
        rend = GetComponentInChildren<MeshRenderer>();
        rend.sortingLayerName = "Text";
        rend.sortingOrder = 1;
    }

    private void Update()
    {
        enemy = FindObjectOfType<Enemy_Skeleton>();

        if (rend.sortingLayerName != "Text")
            rend.sortingLayerName = "Text";
        if (rend.sortingOrder != 1)
            rend.sortingOrder = 1;
    }

    private void OnValidate()
    {
        rend = GetComponentInChildren<MeshRenderer>();
        rend.sortingLayerName = "Text";
        rend.sortingOrder = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (enemy == null)
            {
                Debug.Log("trig충돌");
                //enemy.SetIdleState();
                //Debug.Log(enemy.stateMachine.currentState);
                //player.SetIdleState();
                player.moveSpeed = 0;
                player.stateMachine.ChangeState(player.idleState);
                Change();
            }

            else if (enemy != null)
            {
                StartCoroutine(TextDelete());
            }
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

    IEnumerator TextDelete()
    {
        text.text = "적을 모두 처치하세요";
        yield return new WaitForSeconds(0.8f);
        text.text = "";
    }
}

//private void OnCollisionEnter2D(Collision2D collision)
//{
//    if (collision.collider.CompareTag("Player"))
//    {
//        Debug.Log("col충돌");
//        Change();
//    }
//}