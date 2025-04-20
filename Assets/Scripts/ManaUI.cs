using UnityEngine;
using UnityEngine.UI;

public class ManaUI: MonoBehaviour
{
    public Slider manaSlider;
    public int maxMana = 100;
    private int currentMana;

    private void Start()
    {
        currentMana = maxMana;
        UpdateBar();
    }

    public bool SpendMana(int amount)
    {
        if (currentMana < amount)
            return false;

        currentMana -= amount;
        UpdateBar();
        return true;
    }

    public void GainMana(int amount)
    {
        currentMana = Mathf.Min(currentMana + amount, maxMana);
        UpdateBar();
    }

    void UpdateBar()
    {
        manaSlider.value = (float)currentMana / maxMana;
    }

    public int GetCurrentMana() => currentMana;
}
