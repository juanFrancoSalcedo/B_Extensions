using UnityEngine;

public class EnableDisableArray : MonoBehaviour
{
    [SerializeField] private GameObject[] m_EnableArray;

    public void EnableArray() 
    {
        foreach (GameObject go in m_EnableArray) 
        {    
            go.SetActive(true); 
        }
    }

    public void DisableArray() 
    {
        foreach (GameObject go in m_EnableArray) 
        {
            go.SetActive(false); 
        }
    }
}
