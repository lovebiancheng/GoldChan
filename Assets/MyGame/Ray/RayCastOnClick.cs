using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastOnClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                Debug.Log("µã»÷ÁË" + raycastHit.collider.gameObject.name);
                Renderer renderer = raycastHit.collider.gameObject.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color=Color.red;
                }
            }
        }
    }
}
