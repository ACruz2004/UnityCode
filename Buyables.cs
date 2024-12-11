using UnityEngine;
using TMPro;
using System;

public class Buyables : MonoBehaviour
{
    private bool canPurchase = false;

    [SerializeField]
    public string buyableName;
    public int buyableCost;
    public TextMeshProUGUI prompt;

    private ScoreScript scoreManager;
    private playerMove player;
    AudioSource buySound;

    void Start()
    {
        buySound = GetComponent<AudioSource>();
        scoreManager = FindObjectOfType<ScoreScript>();
        player = FindObjectOfType<playerMove>();
    }

    void OnTriggerEnter(Collider Player)
    {
        if (Player.tag == "Player")
        {
            // Check if player already has the perk
            if (PlayerHasPerk())
            {
                prompt.enabled = false;
                canPurchase = false;
            }
            else
            {
                Debug.Log("Near " + buyableName);
                canPurchase = true;
                prompt.text = "Press [E] to buy " + buyableName + " [Cost: " + buyableCost + "]";
                prompt.enabled = true;
            }
        }
    }

    void Update()
    {
        if (canPurchase && Input.GetKeyDown(KeyCode.E))
        {
            if (scoreManager != null && scoreManager.GetCurrentScore() >= buyableCost)
            {
                PurchasePerk();
                SoundManager.PlaySound(SoundType.BUY);
            }
            else
            {
                Debug.Log($"Not enough points! Current: {scoreManager.GetCurrentScore()}, Required: {buyableCost}");
            }
        }
    }

    void OnTriggerExit(Collider Player)
    {
        if (Player.tag == "Player")
        {
            Debug.Log("Bye bye " + buyableName);
            canPurchase = false;
            prompt.enabled = false;
        }
    }

    // Cheking if the player hasd the perk
    private bool PlayerHasPerk()
    {
        switch (buyableName)
        {
            case "Double Dealer":
                return player.hasDoubleDealer;
            case "Get Jacked":
                return player.hasIronJack;
            case "Ace Revive":
                return player.hasAceRevive;
            case "Quick Draw":
                return player.hasQuickDraw;
            case "Risky Runs":
                return player.hasRiskRunner;
            default:
                return false;
        }
    }

    // Handle the actual purchase logic
    private void PurchasePerk()
    {
        switch (buyableName)
        {
            case "Double Dealer":
                player.hasDoubleDealer = true;
                break;
            case "Get Jacked":
                player.hasIronJack = true;
                break;
            case "Ace Revive":
                player.hasAceRevive = true;
                break;
            case "Quick Draw":
                player.hasQuickDraw = true;
                break;
            case "Risky Runs":
                player.hasRiskRunner = true;
                break;
            default:
                break;
        }

        // Deduct points and disable purchase prompt
        scoreManager.AddScore(-buyableCost);
        canPurchase = false;
        prompt.enabled = false;
        Debug.Log($"{buyableName} purchased");
    }
}