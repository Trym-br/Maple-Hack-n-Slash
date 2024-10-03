using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Sprite emptyHeartSprite;
    [SerializeField] private Sprite filledHeartSprite;
    [SerializeField] private Health playerHealth;

    private int index = 0;
    public void SetHealth()
    {
        foreach (Transform child in transform)
        {
            if (index < playerHealth.hp)
            {
                child.gameObject.GetComponent<Image>().sprite = filledHeartSprite;
            }
            else
            {
                child.gameObject.GetComponent<Image>().sprite = emptyHeartSprite;
            }
            index += 1;
        }
        index = 0;
    }
}
