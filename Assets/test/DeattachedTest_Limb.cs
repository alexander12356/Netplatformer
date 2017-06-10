using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class DeattachedTest_Limb : MonoBehaviour {

    public IEnumerator FadeTo (float initValue, float duration, float timeUntilStart){
        yield return new WaitForSeconds(timeUntilStart);
        SpriteRenderer sprtrndr = GetComponent<SpriteRenderer>();
        Color newColor = new Color(1, 1, 1, 0);
        sprtrndr.color = newColor;
        float alpha = sprtrndr.color.a;

        for (float i = 0; i < 1; i+= Time.deltaTime / duration)
        {
            newColor = new Color(1, 1, 1, Mathf.Lerp(initValue, alpha, i));
            sprtrndr.color = newColor;

            if (i > .98f){
                gameObject.SetActive(false);
            }
            yield return null;
        }
    }
}
