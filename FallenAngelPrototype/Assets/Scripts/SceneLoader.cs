using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    bool fading = false;

    public int nextScene = 1;
    public Image fadeOut;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            if (FindObjectOfType<PlayerFollow>() == null)
            {
                if (fadeOut == null)
                {
                    SceneManager.LoadScene(nextScene);
                }
                else
                {
                    StartCoroutine(Fade());
                    fading = true;
                }
            }
            else if (FindObjectOfType<PlayerFollow>().followNPC == other.transform)
            {
                if (fadeOut == null)
                {
                    SceneManager.LoadScene(nextScene);
                }
                else
                {
                    StartCoroutine(Fade());
                    fading = true;
                }
            }
        }
    }

    void Update()
    {
        if (fading == true)
        {
            fadeOut.color = Color.Lerp(fadeOut.color, Color.black, Time.deltaTime * 20);
        }
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(nextScene);
    }
}
