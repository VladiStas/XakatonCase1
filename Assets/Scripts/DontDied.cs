using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DontDied : MonoBehaviour
{
    // Start is called before the first frame update

    private static Dictionary<string, GameObject> _instances = new Dictionary<string, GameObject>();
    public string ID; // HACK: This ID can be pretty much anything, as long as you can set it from the inspector

    void Awake()
    {
        if (_instances.ContainsKey(ID))
        {
            var existing = _instances[ID];

            // A null result indicates the other object was destoryed for some reason
            if (existing != null)
            {
                if (ReferenceEquals(gameObject, existing))
                    return;

                Destroy(gameObject);

                // Return to skip the following registration code
                return;
            }
        }

        // The following code registers this GameObject regardless of whether it's new or replacing
        _instances[ID] = gameObject;

        DontDestroyOnLoad(gameObject);
    }

}
