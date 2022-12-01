using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class SceneLoad : MonoBehaviour
{
    public Slider progressbar;
    public Text loadText;
    public UnityEvent callBack_evt;

    bool loadComplete = false;

    private void Start()
    {        
        StartCoroutine(LoadScene());
    }

    public void CallBack(float progress)
    {
        if (progress == 1)
        {
            Debug.Log("Calling Event");
            loadComplete = true;
        }
    }

    IEnumerator LoadScene()
    {        
        yield return null;        
        AsyncOperation operation = SceneManager.LoadSceneAsync("PlayScene");        
        operation.allowSceneActivation = false;        

        while (!operation.isDone)
        {            
            yield return null;
            if(progressbar.value < 1f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime * 0.1f);
                Debug.Log("value Check");
            }
            else if(progressbar.value == 1)
            {
                loadText.text = "Loading Success";
                callBack_evt.Invoke();

                if(loadComplete)
                {
                    operation.allowSceneActivation = true;
                }
            }
        }
    }
}
