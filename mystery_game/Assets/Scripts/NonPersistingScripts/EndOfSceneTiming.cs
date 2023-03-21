using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfSceneTiming : MonoBehaviour

{
    public float waitTime = 5f;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Credits");
    }
}
