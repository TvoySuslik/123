using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDtest2.Models // Пространство имен, в котором находится модель
{
    // Модель для таблицы "Cabinet" (Кабинет)
    public class Cabinet
    {
        [Key] // Атрибут, который указывает, что это поле является первичным ключом таблицы
        public int Id { get; set; } // Уникальный идентификатор кабинета

        public string Number { get; set; } // Номер кабинета (например, "101")

        public int FloorId { get; set; } // Идентификатор этажа, на котором находится кабинет

        [ForeignKey("FloorId")] // Указывает, что это поле связано с внешним ключом "FloorId"
        public Floor Floor { get; set; } // Связь с моделью "Floor" (Этаж) по внешнему ключу "FloorId"
    }
}
