using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSystem : MonoBehaviour
{
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public string sceneToLoad;
    public float fadeWait;
    public Animator musicAnim;

    private void Awake()
    {
        if (fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }
    public void MulaiGame()
    {
        StartCoroutine(FadeCo());
    }

    public IEnumerator FadeCo()
    {
        if (fadeOutPanel != null)
        {
            musicAnim.SetTrigger("fadeOut");
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }

    public void QuitGame()
    {
        Debug.Log("quit");
    }
}
