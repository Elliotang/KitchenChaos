 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //counter has nothing
            if (player.HasKitchenObject())
            {
                //player has something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        }
        else
        {
            // counter has an object
            if (player.HasKitchenObject())
            {
                //player has something
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }
                else
                {
                    //player does not have a plate
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        //counter has plate
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO())){
                            player.GetKitchenObject().DestroySelf(); 
                        }
                    }
                }
            }
            else
            {
                // Player has nothing
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        } 
    }
}