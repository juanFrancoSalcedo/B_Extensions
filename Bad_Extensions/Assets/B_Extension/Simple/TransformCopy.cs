
using UnityEngine;

public class TransformCopy : MonoBehaviour
{
    [SerializeField] private Transform otherobject;

    public void SetPosistion() => transform.position = otherobject.position;

    public void SetRotation() => transform.rotation = otherobject.rotation;

    public void SetOtherTransform(Transform newOtherobject) 
    {
        otherobject = newOtherobject;
    } 

    public void SetLocalPositionRotationZero() 
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    public void SetPosRotation() 
    {
        SetPosistion();
        SetRotation();
    }
}
