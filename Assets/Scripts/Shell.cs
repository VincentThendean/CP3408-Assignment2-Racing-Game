using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public float slowEffectDuration = 3.0f;
    public float speedReductionFactor = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        AICarController targetCar = other.GetComponent<AICarController>();
        //GameObject racer = other.GetComponent<GameObject>();
        if (targetCar != null)
        {
            targetCar.StartCoroutine(targetCar.SlowDownAI(slowEffectDuration, speedReductionFactor));
        }

        Destroy(gameObject);
    }
    //private IEnumerator SlowDownAI(AICarController aiCar)
    //{
    //    float originalSpeed = aiCar.agent.speed;
    //    aiCar.agent.speed = originalSpeed * speedReductionFactor;
    //    Debug.Log("Reducing speed");

    //    //yield return new WaitForSeconds(2);

    //    //float elapsedTime = 0.0f;
    //    //while (elapsedTime < slowEffectDuration)
    //    //{
    //    //    aiCar.agent.speed = Mathf.Lerp(originalSpeed * speedReductionFactor, originalSpeed, elapsedTime / slowEffectDuration);
    //    //    elapsedTime += Time.deltaTime;
    //    //}
    //    Debug.Log("wait finish");
    //    yield return new WaitForSeconds(1);

    //    aiCar.agent.speed = originalSpeed;
    //    Debug.Log("return original speed");
    //}
}
