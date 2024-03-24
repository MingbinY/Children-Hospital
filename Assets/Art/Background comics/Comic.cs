using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Comic : MonoBehaviour
{
    [System.Serializable]
    public struct ComicObj
    {
        public GameObject comic;
        public float waitTime;
    }

    public List<ComicObj> comics;
    private void Start()
    {
        StartCoroutine(ComicSequence());
    }

    IEnumerator ComicSequence()
    {
        yield return null;
        int i = 0;
        while (i < comics.Count)
        {
            comics[i].comic.SetActive(true);
            yield return new WaitForSeconds(comics[i].waitTime);
            i++;
        }
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(1);
    }
}
