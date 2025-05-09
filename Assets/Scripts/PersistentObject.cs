using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentObject : MonoBehaviour
{
    public static string staticPublicDebugText = "StaticDebug";
    private static string staticPrivateDebugText = "";
    private string instancePrivateDebugText = "instance private";
    public string instancePublicDebugText = "instance public";

    private static PersistentObject staticInstance;

    void Awake()
    {
        if (staticInstance == null)
        {
            Destroy(gameObject);
            return;
        }
        staticInstance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static PersistentObject GetInstace()
    {
        return staticInstance;
    }

    void Start()
    {
        staticPublicDebugText = "Hello (public)";
        staticPrivateDebugText = "Hello (private)";
        StartCoroutine(Loop());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Load Scene Singleton02");
            SceneManager.LoadScene("Singleton02");
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Loop()
    {
        while (true)
        {
            Debug.Log($"static - publicDebugText: {staticPublicDebugText}");
            Debug.Log($"static - privateDebugText: {staticPrivateDebugText}");
            Debug.Log($"instance - publicDebugText: {instancePublicDebugText}");
            Debug.Log($"instance - privateDebugText: {instancePrivateDebugText}");
            yield return new WaitForSeconds(1);
        }
    }

    public static void SetStaticPrivateText(string text)
    {
        staticPrivateDebugText = text;
    }

    public static string StaticPrivateText()
    {
        return staticPrivateDebugText;
    }

    public void SetInstancePrivateText(string text)
    {
        instancePrivateDebugText = text;
    }

}
