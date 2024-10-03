using UnityEngine;
using UnityEngine.UIElements;

public class HealthUI : MonoBehaviour
{
    private VisualElement[] hearts;

    [SerializeField] private Sprite emptyHeartSprite;
    [SerializeField] private Sprite filledHeartSprite;
}
