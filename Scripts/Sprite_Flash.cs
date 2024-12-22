using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_Flash : MonoBehaviour,ISPrite_Flash
//繼承interface時候，如果interface沒有給定參數時候，不用先給定參數類別
{
    public SpriteRenderer spriteRenderer;
    [Tooltip("Damage所需要的時間")]
    public float flashDuration;
    [Tooltip("Damage的閃爍次數")]
    [Range(0f, 4f)]
    public int flashNumber;
    public Color flashColor;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void FlashSprite(SpriteRenderer _spriteRenderer, float _flashDuration, Color _flashColor, int _flashNumber)
    {
        spriteRenderer = _spriteRenderer;
        flashNumber = _flashNumber;
        flashColor = _flashColor; // Set flash color to white
        StartCoroutine(FlashRoutine(spriteRenderer, flashDuration, flashColor, flashNumber));
    }

    private IEnumerator FlashRoutine(SpriteRenderer spriteRenderer, float flashDuration, Color flashColor, int flashNumber)
    {
        Color startColor = spriteRenderer.color;
        float elapsedFlashTime = 0f;
    
        while (elapsedFlashTime < flashDuration)
        {
            elapsedFlashTime += Time.deltaTime*7f;//乘上7倍是因為，在Update更新時候，sprite會來不及更新回來，因此放大elpasedTime
            float elapsedFlashPercentage = Mathf.Clamp01(elapsedFlashTime / flashDuration);

            // Calculate the PingPong percentage to create the flash effect
            float pingpongPercentage = Mathf.PingPong(elapsedFlashPercentage * flashNumber * 2, 1);
            spriteRenderer.color = Color.Lerp(startColor, flashColor, pingpongPercentage);

           yield return null;
        }

        // Reset to the original color once the flashing is done
        spriteRenderer.color = startColor;
    }

}
