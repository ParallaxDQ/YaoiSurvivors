using UnityEngine;

public abstract class AbstractItem : MonoBehaviour
{
    [SerializeField] Sprite itemSprite;
    [SerializeField] float cooldownSecs;

    public abstract float itemFunc(float increaseVar);
}
