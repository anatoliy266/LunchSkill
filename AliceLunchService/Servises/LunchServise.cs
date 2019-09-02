using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AliceLunchService.Models;
using System.Data;
using System.Data.SqlClient;

namespace AliceLunchService.Servises
{
    public class LunchServise
    {
        private List<AliseDialodItem> dialogueItems = new List<AliseDialodItem>();
        public int IDSkill { get => skillid; set => skillid = value; }

        private int skillid;
        public LunchServise()
        {
            //помощь
            dialogueItems.Add(new AliseDialodItem() {
                Id = 1,
                ItemDesc = "help",
                SkillId = 3,
                ParentId = 0,
                KeyWords = new List<string[]>() { new string[] { "помощь" } }
            });

            //что ты умеешь
            dialogueItems.Add(new AliseDialodItem()
            {
                Id = 2,
                ItemDesc = "skils",
                SkillId = 3,
                ParentId = 0,
                KeyWords = new List<string[]>() { new string[] { "что" }, new string[] { "ты" }, new string[] { "умеешь" }, }
            });

            //вода

            dialogueItems.Add(new AliseDialodItem()
            {
                Id = 3,
                ItemDesc = "water",
                SkillId = 3,
                ParentId = 0,
                KeyWords = new List<string[]>() { new string[] { "помощь" } }
            });

            //история заказов

            dialogueItems.Add(new AliseDialodItem()
            {
                Id = 4,
                ItemDesc = "ordersHistory",
                SkillId = 3,
                ParentId = 0,
                KeyWords = new List<string[]>() { new string[] { "история", "историю" }, new string[] { "заказов" }, }
            });

            //что в корзине

            dialogueItems.Add(new AliseDialodItem()
            {
                Id = 5,
                ItemDesc = "basket",
                SkillId = 3,
                ParentId = 0,
                KeyWords = new List<string[]>() { new string[] { "корзину", "заказ" }, new string[] { "расскажи", "открой" } }
            });

            //меню

            dialogueItems.Add(new AliseDialodItem()
            {
                Id = 6,
                ItemDesc = "menu",
                SkillId = 3,
                ParentId = 0,
                KeyWords = new List<string[]>() { new string[] { "расскажи", "открой" }, new string[] { "меню" } }
            });

            //холодные блюда

            dialogueItems.Add(new AliseDialodItem()
            {
                Id = 7,
                ItemDesc = "menuCold",
                SkillId = 3,
                ParentId = 6,
                KeyWords = new List<string[]>() { new string[] { "холодные" }, new string[] { "закуски" } }
            });

            //горячее

            dialogueItems.Add(new AliseDialodItem()
            {
                Id = 8,
                ItemDesc = "MenuHot",
                SkillId = 3,
                ParentId = 6,
                KeyWords = new List<string[]>() { new string[] { "горячие" }, new string[] { "блюда" } }
            });

            //напитки

            dialogueItems.Add(new AliseDialodItem()
            {
                Id = 9,
                ItemDesc = "menuDrink",
                SkillId = 3,
                ParentId = 6,
                KeyWords = new List<string[]>() { new string[] { "напитки" } }
            });

            //начало заказа

            dialogueItems.Add(new AliseDialodItem()
            {
                Id = 10,
                ItemDesc = "orderBegin",
                SkillId = 3,
                ParentId = 0,
                KeyWords = new List<string[]>() { new string[] { "закажи", "заказать" } }
            });

            //выбор блюд для заказа

            dialogueItems.Add(new AliseDialodItem()
            {
                Id = 11,
                ItemDesc = "orderAdd",
                SkillId = 3,
                ParentId = 10,
                KeyWords = new List<string[]>() { new string[] { "добавь", "еще" } }
            });

            //конец заказа

            dialogueItems.Add(new AliseDialodItem()
            {
                Id = 12,
                ItemDesc = "orderEnd",
                SkillId = 3,
                ParentId = 10,
                KeyWords = new List<string[]>() { new string[] { "заказ" }, new string[] { "оформить", "сделать", "сделай" } }
            });

            //доставка

            dialogueItems.Add(new AliseDialodItem()
            {
                Id = 13,
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


        private SqlConnection Connect()
        {
            SqlConnection connection = new SqlConnection();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "(local\\sqlexpress)";
            builder.InitialCatalog = "master";
            connection.ConnectionString = builder.ConnectionString;
            return connection;
        }
        public string ProcessLunchRequest(AliceRequest request)
        {
            if (request.Request.nlu.tokens.Count() == 0)
            {
                return "";
            } else
            {
                var item = GetDialogItem(request.Request.nlu.tokens);
                switch (item.Id)
                {
                    case 1:
                        {
                            return "helpstring";
                        }
                    case 2:
                        {
                            return "skillstring";
                        }
                    case 3:
                        {
                            return "waterstring";
                        }
                    case 4:
                        {
                            //история заказов
                            DataSet data = new DataSet();

                            SqlCommand command = new SqlCommand("AliseLunchServise", this.Connect());
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("session", request.Session.SessionId);
                            command.Parameters.AddWithValue("action", "GET");
                            command.Parameters.AddWithValue("target", "HISTORY");
                            SqlDataAdapter adapter = new SqlDataAdapter(command);
                            
                            adapter.Fill(data);

                            string orderDesc = "";

                            foreach (DataRow row in data.Tables[0].Rows)
                            {
                                orderDesc += row.ItemArray[data.Tables[0].Columns.IndexOf("date")] + " : Заказ номер" + row.ItemArray[data.Tables[0].Columns.IndexOf("idOrder")] + "\r\n";
                            }
                            return "Вы заказывали: \r\n" + orderDesc;
                        }
                    case 5:
                        {
                            //корзина
                            DataSet data = new DataSet();

                            SqlCommand command = new SqlCommand("AliseLunchServise", this.Connect());
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("session", request.Session.SessionId);
                            command.Parameters.AddWithValue("action", "GET");
                            command.Parameters.AddWithValue("target", "BASKET");
                            SqlDataAdapter adapter = new SqlDataAdapter(command);

                            adapter.Fill(data);

                            string basketDesk = "";

                            foreach (DataRow row in data.Tables[0].Rows)
                            {
                                basketDesk += row.ItemArray[data.Tables[0].Columns.IndexOf("itemName")] + "\r\n";
                            }
                            return "Вы заказали: \r\n" + basketDesk;
                        }
                    case 6:
                        {
                            //меню
                            DataSet data = new DataSet();

                            SqlCommand command = new SqlCommand("AliseLunchServise", this.Connect());
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("session", request.Session.SessionId);
                            command.Parameters.AddWithValue("action", "GET");
                            command.Parameters.AddWithValue("target", "MENU");
                            SqlDataAdapter adapter = new SqlDataAdapter(command);

                            adapter.Fill(data);

                            string menuCategoryDesc = "";

                            foreach (DataRow row in data.Tables[0].Rows)
                            {
                                menuCategoryDesc += row.ItemArray[data.Tables[0].Columns.IndexOf("itemName")] + "\r\n";
                            }
                            return "выберите категорию: \r\n" + menuCategoryDesc;
                        }
                    case 7:
                        {
                            //cold
                            DataSet data = new DataSet();

                            SqlCommand command = new SqlCommand("AliseLunchServise", this.Connect());
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("session", request.Session.SessionId);
                            command.Parameters.AddWithValue("action", "GET");
                            command.Parameters.AddWithValue("target", "MENU");
                            SqlDataAdapter adapter = new SqlDataAdapter(command);

                            adapter.Fill(data);
                            break;
                        }
                    case 8:
                        {
                            //hot
                            DataSet data = new DataSet();

                            SqlCommand command = new SqlCommand("AliseLunchServise", this.Connect());
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("session", request.Session.SessionId);
                            command.Parameters.AddWithValue("action", "GET");
                            command.Parameters.AddWithValue("target", "MENU");
                            SqlDataAdapter adapter = new SqlDataAdapter(command);

                            adapter.Fill(data);
                            break;
                        }
                    case 9:
                        {
                            //drink
                            DataSet data = new DataSet();

                            SqlCommand command = new SqlCommand("AliseLunchServise", this.Connect());
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("session", request.Session.SessionId);
                            command.Parameters.AddWithValue("action", "GET");
                            command.Parameters.AddWithValue("target", "MENU");
                            SqlDataAdapter adapter = new SqlDataAdapter(command);

                            

                            adapter.Fill(data);
                            break;
                        }
                    case 10:
                        {
                            //orderbegin
                            DataSet data = new DataSet();

                            SqlCommand command = new SqlCommand("AliseLunchServise", this.Connect());
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("session", request.Session.SessionId);
                            command.Parameters.AddWithValue("action", "ADD");
                            command.Parameters.AddWithValue("target", "NEWSESSION");
                            SqlDataAdapter adapter = new SqlDataAdapter(command);

                            adapter.Fill(data);
                            break;
                        }
                    case 11:
                        {
                            //addToOrder
                            DataSet data = new DataSet();

                            SqlCommand command = new SqlCommand("AliseLunchServise", this.Connect());
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("session", request.Session.SessionId);
                            command.Parameters.AddWithValue("action", "ADD");
                            SqlDataAdapter adapter = new SqlDataAdapter(command);

                            adapter.Fill(data);
                            break;
                        }
                    case 12:
                        {
                            //order end
                            break;
                        }
                    case 13:
                        {
                            break;
                        }
                    default:
                        {
                            return "абсолютно неожиданная ошибка";
                        }
                }
            }
        }

        private AliseDialodItem GetDialogItem(string[] tokens)
        {
            var skillDialogItems = dialogueItems.Where(x => x.SkillId == IDSkill);
            foreach (var item in skillDialogItems)
            {
                if (tokens.Count() < item.KeyWords.Count)
                {
                    return null;
                } else
                {
                    bool bIsContains = false;
                    foreach (var key in item.KeyWords)
                    {
                        if (key.Intersect(tokens).Count() > 0)
                        {
                            bIsContains = true;
                        }
                    }
                    if (bIsContains == true)
                    {
                        return item;
                    } else
                    {
                        return null;
                    }
                }
            }
        }
    }
}




 
 /*   // <summary>
/// Обработка запроса Алисы для навыка "Жребий"
/// </summary>
/// <param name="aliceRequest"></param>
/// <returns></returns>
public string ProcessLotRequest(AliceRequest aliceRequest)
{
try
{
if (aliceRequest.Request.nlu.tokens.Count() == 0)
{
return "Здравствуйте! Хотите, чтобы я выбрала случайным образом кого-то из списка? Скажите: \"Запоминай имена!\"";
}
else
{
var lotService = new AliceLotService(Settings);
var session = lotService.Get(aliceRequest.Session.SessionId);

var result = MatchDialogState(aliceRequest.Request.nlu.tokens, 2);
if (result == null)
{
if (session == null) return "Не могу понять, чего вы хотите. Повторите команду.";
var entities = aliceRequest.Request.nlu.Entity;
//пытаемся распознать имя, если сессия начата
if (entities.Count() > 0)
{
//есть определенные алисой сущности
foreach (var ent in entities)
{
if (ent.Type == "YANDEX.FIO" && ent.Values.FirstName != null)
{
//сущность - имя
Dictionary<string, object> parameters = new Dictionary<string, object>();
var lastName = ent.Values.LastName != "" ? (" " + ent.Values.LastName) : "";
var name = ent.Values.FirstName + lastName;
var response = lotService.Add(aliceRequest.Session.SessionId, name);
if (response == "")
{
return $"Имя {name} внесено в список. Скажите следующее имя или дайте команду: \"Кидай жребий!\" для поиска среди имен";
}
else
{
// ошибка пытаемся удалить сессию
lotService.Finish(aliceRequest.Session.SessionId);
return "К сожалению произошла ошибка. Попробуйте перезапустить навык. Прошу прощения за доставленные неудобства.";
}
}
}
}
// если алиса сущности не распознала, так и передадим
return "Не могу распознать имя. Попробуйте назвать какое-нибудь другое.";
}
else
{
// команда получена и она распознана
if (result.Id == 1)
{
// получена команда "слушай", создаем сессию
if (lotService.Start(aliceRequest.Session.SessionId) == "")
{
return "Хорошо. Скажите имя и, если хотите, фамилию претендента";
}
else
{
lotService.Finish(aliceRequest.Session.SessionId);
return "К сожалению произошла ошибка. Попробуйте перезапустить навык. Прошу прощения за доставленные неудобства.";
}

 
}
else if (result.Id == 2)
{
// получена команда "хватит"
var name = lotService.GetResult(aliceRequest.Session.SessionId);
if (name.Contains("Error"))
{
return "К сожалению произошла ошибка. Попробуйте перезапустить навык. Прошу прощения за доставленные неудобства.";
}
else
{
return name;
}
}else if (result.Id == 3)
{
// помошь
return "Для того, чтобы я начала запоминать имена для случайного выбора, скажите: \"Запоминай имена!\". Для того, чтобы я сделала свой выбор, скажите \"Кидай жребий!\"";
}
else if (result.Id == 4)
{
// что ты умеешь
return "Навык \"Жребий\" позволяет случайным образом выбрать имя из списка. К примеру, навык можно использовать для выбора того, кто первый пойдет на обед, или заплатит за него.";
}
}
return "Произошла ошибка, попробуйте снова позже";
}
}
catch(Exception ex)
{
logger.Error(ex);
return "К сожалению произошла ошибка. Попробуйте перезапустить навык. Прошу прощения за доставленные неудобства.";
}

}
     */
