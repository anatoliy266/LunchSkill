using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AliceLunchService.Models;

namespace AliceLunchService.Servises
{
    public class LunchServise
    {
        private List<AliseDialodItem> tokens = new List<AliseDialodItem>();
        public LunchServise()
        {
            //помощь
            tokens.Add(new AliseDialodItem() {
                Id = 1,
                ItemDesc = "help",
                SkillId = 3,
                ParentId = 0,
                KeyWords = new List<string[]>() { new string[] { "помощь" } }
            });

            //что ты умеешь
            tokens.Add(new AliseDialodItem()
            {
                Id = 2,
                ItemDesc = "skils",
                SkillId = 3,
                ParentId = 0,
                KeyWords = new List<string[]>() { new string[] { "что" }, new string[] { "ты" }, new string[] { "умеешь" }, }
            });

            //вода

            tokens.Add(new AliseDialodItem()
            {
                Id = 3,
                ItemDesc = "water",
                SkillId = 3,
                ParentId = 0,
                KeyWords = new List<string[]>() { new string[] { "помощь" } }
            });

            //история заказов

            tokens.Add(new AliseDialodItem()
            {
                Id = 4,
                ItemDesc = "ordersHistory",
                SkillId = 3,
                ParentId = 0,
                KeyWords = new List<string[]>() { new string[] { "история", "историю" }, new string[] { "заказов" }, }
            });

            //что в корзине

            tokens.Add(new AliseDialodItem()
            {
                Id = 5,
                ItemDesc = "basket",
                SkillId = 3,
                ParentId = 0,
                KeyWords = new List<string[]>() { new string[] { "корзину", "заказ" }, new string[] { "расскажи", "открой" } }
            });

            //меню

            tokens.Add(new AliseDialodItem()
            {
                Id = 6,
                ItemDesc = "menu",
                SkillId = 3,
                ParentId = 0,
                KeyWords = new List<string[]>() { new string[] { "расскажи", "открой" }, new string[] { "меню" } }
            });

            //холодные блюда

            tokens.Add(new AliseDialodItem()
            {
                Id = 7,
                ItemDesc = "menuCold",
                SkillId = 3,
                ParentId = 6,
                KeyWords = new List<string[]>() { new string[] { "холодные" }, new string[] { "закуски" } }
            });

            //горячее

            tokens.Add(new AliseDialodItem()
            {
                Id = 8,
                ItemDesc = "MenuHot",
                SkillId = 3,
                ParentId = 6,
                KeyWords = new List<string[]>() { new string[] { "горячие" }, new string[] { "блюда" } }
            });

            //напитки

            tokens.Add(new AliseDialodItem()
            {
                Id = 9,
                ItemDesc = "menuDrink",
                SkillId = 3,
                ParentId = 6,
                KeyWords = new List<string[]>() { new string[] { "напитки" } }
            });

            //начало заказа

            tokens.Add(new AliseDialodItem()
            {
                Id = 10,
                ItemDesc = "orderBegin",
                SkillId = 3,
                ParentId = 0,
                KeyWords = new List<string[]>() { new string[] { "закажи", "заказать" } }
            });

            //выбор блюд для заказа

            tokens.Add(new AliseDialodItem()
            {
                Id = 11,
                ItemDesc = "orderAdd",
                SkillId = 3,
                ParentId = 10,
                KeyWords = new List<string[]>() { new string[] { "добавь", "еще" } }
            });

            //конец заказа

            tokens.Add(new AliseDialodItem()
            {
                Id = 12,
                ItemDesc = "orderEnd",
                SkillId = 3,
                ParentId = 10,
                KeyWords = new List<string[]>() { new string[] { "заказ" }, new string[] { "оформить", "сделать", "сделай" } }
            });

            //доставка

            tokens.Add(new AliseDialodItem()
            {
                Id = 12,
                ItemDesc = "delivery",
                SkillId = 3,
                ParentId = 10,
                KeyWords = new List<string[]>() { new string[] { "доставку" }, new string[] { "оформи", "организуй" } }
            });

            //адрес доставки

            /*tokens.Add(new AliseDialodItem()
            {
                Id = 12,
                ItemDesc = "deliveryAddress",
                SkillId = 3,
                ParentId = 10,
                KeyWords = new List<string[]>() { new string[] { "помощь" } }
            });

            //телефон

            tokens.Add(new AliseDialodItem()
            {
                Id = 12,
                ItemDesc = "deliveryPhone",
                SkillId = 3,
                ParentId = 10,
                KeyWords = new List<string[]>() { new string[] { "помощь" } }
            });*/
        }
    }
}
