using UnityEditor;
using UnityEngine;

public class KonturObiektu : MonoBehaviour
{

    public float maxZasieg = 2f;
    public LayerMask ignore;

    private bool canDraw = true;


    private void Start()
    {
        EventSystem.DialogueStart += OnDialogueStart;
        EventSystem.DialogueEnd += OnDialogueEnd;

    }

    public void OnDialogueStart(object sender, EventArgs args)
    {
        canDraw = false;
    }

    public void OnDialogueEnd(object sender, EventArgs args)
    {
        canDraw = true;
    }

    void Update()
    {
        if (!canDraw) return;

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(ray, out RaycastHit hitinfo, maxZasieg, ~ignore)) 
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