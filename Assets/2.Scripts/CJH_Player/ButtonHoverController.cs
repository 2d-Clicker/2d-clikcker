using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetBool("MouseOver", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetBool("MouseOver", false);
    }
}
