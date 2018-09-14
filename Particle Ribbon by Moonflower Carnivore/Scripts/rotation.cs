using System.Collections;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public float xRotation = 0F;
    public float yRotation = 0F;
    public float zRotation = 0F;
    void Start()
    {
        InvokeRepeating("rotate", 0f, 0.0167f);
    }
    void OnDisable()
    {
        CancelInvoke();
    }
    public void clickOn()
    {
        InvokeRepeating("rotate", 0f, 0.0167f);
    }
    public void ClickOff()
    {
        CancelInvoke();
    }

    public override string ToString()
    {
        return base.ToString();
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override bool Equals(object other)
    {
        return base.Equals(other);
    }
}