using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T S;

    public virtual void Awake()
    {
        S = this as T;
    }


}