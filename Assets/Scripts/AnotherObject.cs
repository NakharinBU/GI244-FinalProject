using UnityEngine;

public class AnotherObject : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("staticDebugText: " + PersistentObject.staticPublicDebugText);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            PersistentObject.staticPublicDebugText = "B";
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            string t = PersistentObject.StaticPrivateText();
            PersistentObject.SetStaticPrivateText("C");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            var p = GameObject.Find("PersisntentObject").GetComponent<PersistentObject>();

            p.instancePublicDebugText = "D";
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            PersistentObject.GetInstace().instancePublicDebugText = "E";
        }
    }
}
