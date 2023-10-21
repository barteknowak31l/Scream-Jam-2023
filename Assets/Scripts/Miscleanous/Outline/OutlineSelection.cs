using UnityEditor;
using UnityEngine;

public class KonturObiektu : MonoBehaviour
{

    public float maxZasieg = 2f;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(ray, out RaycastHit hitinfo, maxZasieg)) 
        {
            if (hitinfo.collider.gameObject.TryGetComponent(out OutlineHandle obj))
            {
                obj.OutlineOn();

            }
            else
            {
               // obj.OutlineOff();

            }
        }
    }

}