using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public int health = 100, maxHealth = 100;
    private Slider healthbarSlider;

    public static Healthbar Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
        healthbarSlider = GetComponent<Slider>();
        healthbarSlider.maxValue = maxHealth;
        healthbarSlider.value = health;

    }

    public void UpdateHealthBarValue (int value)
    {
        healthbarSlider.value = value;
    }

}
