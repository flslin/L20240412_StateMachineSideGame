using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange1 : MonoBehaviour
{
    public Collider2D door;
    
    public Image image;
    Scene scene;

    private void Start()
    {
        scene = SceneManager.GetActiveScene();

        if (scene.name == "New Scene")
            Change();
    }

    void Change()
    {
        StartCoroutine(SChange2());
    }

    IEnumerator SChange2()
    {
        float startAlpha = 1;
        image.fillOrigin = (int)Image.OriginHorizontal.Left;
        while (startAlpha > 0)
        {
            startAlpha -= 0.01f;
            yield return new WaitForSeconds(0.015f);
            image.fillAmount = startAlpha;
            //image.color = new Color(0, 0, 0, startAlpha);
        }
    }
}
