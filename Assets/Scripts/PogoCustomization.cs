using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PogoCustomization : MonoBehaviour
{
   [SerializeField] private Material bodyMaterial, handlesMaterial, crossbarMaterial, baseMaterial, ballMaterial;

   public void ChangeBodyColor(Color color)
    {
        if (bodyMaterial != null)
        {
            bodyMaterial.color = color;
        }
    }

    public void ChangeHandlesColor(Color color)
    {
        if (handlesMaterial != null)
        {
            handlesMaterial.color = color;
        }
    }

    public void ChangeCrossbarColor(Color color)
    {
        if (crossbarMaterial != null)
        {
            crossbarMaterial.color = color;
        }
    }

    public void ChangeBaseColor(Color color)
    {
        if (baseMaterial != null)
        {
            baseMaterial.color = color;
        }
    }

    public void ChangeBallColor(Color color)
    {
        if (ballMaterial != null)
        {
            ballMaterial.color = color;
        }
    }
}
