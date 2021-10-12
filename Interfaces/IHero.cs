using UnityEngine;

public interface IHero
{
    public float health { get; set; }
    public void Health(IBullet bullet);
    public void Position();
    public void Rotate(string Tag);
    public void Throw(GameObject bulletObject, float force);
    public void Death();
}