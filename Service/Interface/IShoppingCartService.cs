﻿using Domain.Domain;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IShoppingCartService
    {
        ShoppingCartDto getShoppingCartInfo(string userId);
        bool deleteProductFromShoppingCart(string userId, Guid productId);
        bool order(string userId, string Address);
        bool AddToShoppingConfirmed(FoodInShoppingCart model, string userId);
        bool IncreaseQantityForProduct(string userId,Guid productId);
        bool DecreaseQantityForProduct(string userId, Guid productId);
    }
}
