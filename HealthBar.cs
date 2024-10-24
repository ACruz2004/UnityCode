using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    float health = 1;

    public void PlayerDamage(float damage)
    {
        health -= damage;

        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);

        if (health <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        }
    }
}
