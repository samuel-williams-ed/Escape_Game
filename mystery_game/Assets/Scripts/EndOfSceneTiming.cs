using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfSceneTiming : MonoBehaviour

{
    IEnumerator Start() {
        yield return new WaitForSeconds(15f);
        SceneManager.LoadScene("Credits");
    }
}
