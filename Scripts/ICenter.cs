using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 和Sprite有關
// public interface ISPrite_Flash<T>//只能先給定泛型，等實作後繼承之後，再給定類別
// {
//     void FlashSprite(T renderer);
// }

public interface ISPrite_Flash//也可以在方法中再給定參數
{
    void FlashSprite(SpriteRenderer spriteRenderer,float flashDuration,Color color,int flashNumber);
}
#endregion

#region 說明要不要給定參數
// public interface ISpriteFlash
// {
//     void FlashSprite(SpriteRenderer renderer);
// }
// ISpriteFlash is now a non-generic interface, 
// and FlashSprite explicitly expects a SpriteRenderer as a parameter. 
//所以不一定要在interface給定泛型參數，也可以在方法中定義參數的類別
#endregion


#region 和HP有關
// public interface IDamage<T>//如果要在Interfece先給定參數的話，只能先給定泛型，等實作後，再給定類別
// {
//     void HandleDamage(T damage);
// }

//也可以改成
public interface IDamage
{
   void HandleDamage(float damage);
}
#endregion
